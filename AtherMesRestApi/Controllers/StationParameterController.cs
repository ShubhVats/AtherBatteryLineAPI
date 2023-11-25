using System.Linq;
using System.Threading.Tasks;
using AtherMesRestApi.MESModels;
using AtherMesRestApi.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AtherMesRestApi.Controllers
{
    [Route("api/stationparameter")]
    [ApiController]

    public class StationParameterController : Controller
    {
        private readonly MESDBContext _context;

        public StationParameterController(MESDBContext context)
        {
            _context = context;
        }

        //GET: api/SapOrders/5

        [HttpGet("{line}")]
        public async Task<ActionResult<ResponseStationParameter>> GetUserWithRoleLineStation(string line)
        {
            ResponseStationParameter res;
            //var ParameterList = await _context.StationParameter.OrderBy(a => a.SequenceNo).OrderBy(a => a.StationName)
            var ParameterList = await _context.StationParameter
                 .ToListAsync();

            if (ParameterList == null)
            {
                res = new ResponseStationParameter("data not found", 300, null);
                //return NotFound();
            }
            else
            {
                res = new ResponseStationParameter("data found", 200, ParameterList);
            }

            return res;
        }
    }
}
