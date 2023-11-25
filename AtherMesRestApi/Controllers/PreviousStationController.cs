using System.Linq;
using System.Threading.Tasks;
using AtherMesRestApi.MESModels;
using AtherMesRestApi.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AtherMesRestApi.Controllers
{
    [Route("api/previousStation")]
    [ApiController]
    public class PreviousStationController : Controller
    {
        private readonly MESDBContext _context;

        public PreviousStationController(MESDBContext context)
        {
            _context = context;
        }

        //GET: api/SapOrders/5

        [HttpGet("{deviceID}/{line}")]
        public async Task<ActionResult<ResponsePreviousStation>> GetPreviousStation(int deviceID, string line)
        {
            ResponsePreviousStation responsePreviousStation;
            var PreviousStationList = await _context.PreviousStation.Where(a => a.DeviceId.Equals(deviceID))
                 .ToListAsync();

            if (PreviousStationList == null)
            {
                responsePreviousStation = new ResponsePreviousStation("data not found", 300, null);
                //return NotFound();
            }
            else
            {
                if (PreviousStationList.Count > 0)
                {
                    responsePreviousStation = new ResponsePreviousStation("data found", 200, PreviousStationList);

                }
                else
                {
                    responsePreviousStation = new ResponsePreviousStation("data not found", 300, null);

                }

            }

            return responsePreviousStation;
        }
    }
}
