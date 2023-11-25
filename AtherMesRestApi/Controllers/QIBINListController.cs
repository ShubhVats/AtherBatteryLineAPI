using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtherMesRestApi.MESModels;
using AtherMesRestApi.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AtherMesRestApi.Controllers
{
    [Route("api/GetBinDetails")]
    [ApiController]
    public class QIBINListController : Controller
    {
        private readonly MESDBContext _context;

        public QIBINListController(MESDBContext context)
        {
            _context = context;
        }

        [HttpGet("{bin_number}/{status}/{line}")]
        public async Task<ActionResult<ResponseRejectionBins>> GetBinDetails(string bin_number, int status, string line)
        {
            ResponseRejectionBins responseRejectionBins;

            List<GetBatteryDetails> GetBatteryDetails = new List<GetBatteryDetails>();

            GetBatteryDetails = await _context.GetBatteryDetails.Where(a => a.BIN_Number.Equals(bin_number) && a.Status.Equals(status) && !a.ParameterVal.Equals("0") && !a.ParameterVal.Equals("1"))
                 .ToListAsync();


            if (GetBatteryDetails == null)
            {
                responseRejectionBins = new ResponseRejectionBins("data not found", 300, null);
                //return NotFound();
            }
            else
            {
                if (GetBatteryDetails.Count > 0)
                {
                    responseRejectionBins = new ResponseRejectionBins("data found", 200, GetBatteryDetails);

                }
                else
                {
                    responseRejectionBins = new ResponseRejectionBins("data not found", 300, null);
                }

            }

            return responseRejectionBins;
        }

        [HttpGet("Common/{bin_number}/{status}/{line}")]
        public async Task<ActionResult<ResponseRejectionBinsCommon>> GetBinDetailsCommon(string bin_number, int status, string line)
        {
            ResponseRejectionBinsCommon responseRejectionBins;

            List<GetBatteryDetailsCommon> GetBatteryDetails = new List<GetBatteryDetailsCommon>();

            GetBatteryDetails = await _context.GetBatteryDetailsCommon.Where(a => a.BIN_Number.Equals(bin_number) && a.Status.Equals(status) && !a.ParameterVal.Equals("0"))
                 .ToListAsync();


            if (GetBatteryDetails == null)
            {
                responseRejectionBins = new ResponseRejectionBinsCommon("data not found", 300, null);
                //return NotFound();
            }
            else
            {
                if (GetBatteryDetails.Count > 0)
                {
                    responseRejectionBins = new ResponseRejectionBinsCommon("data found", 200, GetBatteryDetails);

                }
                else
                {
                    responseRejectionBins = new ResponseRejectionBinsCommon("data not found", 300, null);
                }

            }

            return responseRejectionBins;
        }

    }
}
