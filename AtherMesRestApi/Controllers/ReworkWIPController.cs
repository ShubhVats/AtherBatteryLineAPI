using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AtherMesRestApi.MESModels;
using AtherMesRestApi.ResponseModel;
using System.Linq;
using AtherMesRestApi.DtoModels;
using System.Collections.Generic;

namespace AtherMesRestApi.Controllers
{

    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/ReworkWIPService")]
    [ApiController]

    public class ReworkWIPController : ControllerBase
    {
        private readonly MESDBContext _context;

        public ReworkWIPController(MESDBContext context)
        {
            _context = context;
        }
        [HttpPost("SaveAipDetails/{line}")]

        public async Task<string> SaveAipDetails(ReworkWIP reworkWIP, string line)
        {
            //List<StandardResponseProductionOrder> resp = new List<StandardResponseProductionOrder>();
            string status = string.Empty;

            try
            {
                _context.ReworkWIP.Add(reworkWIP);
                await _context.SaveChangesAsync();
                status = "Success";

            }
            catch (DbUpdateException e)
            {
                status = "Failure";
                return status;
            }
            return status;
        }
    }
}