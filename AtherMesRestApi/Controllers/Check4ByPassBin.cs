using System;
using System.Linq;
using System.Threading.Tasks;
using AtherMesRestApi.MESModels;
using AtherMesRestApi.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AtherMesRestApi.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/Check4ByPassBin")]
    [ApiController]
    public class Check4ByPassBin : ControllerBase
    {
        private readonly MESDBContext _context;

        public Check4ByPassBin(MESDBContext context)
        {
            _context = context;
        }

        //GET: api/SapOrders/5

        [HttpGet("{binNumber}/{line}")]
        public async Task<ActionResult<ResponseSave>> CheckbyPassBin(string binNumber, string line)
        {
            string status = string.Empty;
            ResponseSave responseSave;

            var wipBinList = await _context.BatteryWIP.Where(a => a.BIN_Number.Equals(binNumber) && (a.Status.Equals(3) || a.Status.Equals(4))).ToListAsync();
            Console.WriteLine("count " + wipBinList.Count());
            if (wipBinList.Count <= 0)
            {
                status = "Success";
            }
            else
            {
                status = "Failure";
            }
            if (status == "Success")
            {
                responseSave = new ResponseSave("New BIN!", 200);
            }
            else
            {
                responseSave = new ResponseSave("ByPass BIN!", 300);
            }

            return responseSave;
        }
    }
}
