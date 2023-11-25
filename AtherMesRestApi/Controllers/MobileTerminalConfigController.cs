using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AtherMesRestApi.MESModels;
using AtherMesRestApi.ResponseModel;
using System.Linq;

namespace AtherMesRestApi.Controllers
{
    [Route("api/mobileterminalconfigservice")]
    [ApiController]
    public class MobileTerminalConfigController : ControllerBase
    {
        private readonly MESDBContext _context;

        public MobileTerminalConfigController(MESDBContext context)
        {
            _context = context;
        }

        //GET: api/SapOrders/5

        [HttpGet("{MACAddress}")]
        public async Task<ActionResult<ResponseConfigMobileTerminal>> GetMobileTerminalWithMACAddress(string MACAddress)
        {
            ResponseConfigMobileTerminal responseConfigMobileTerminal;
            var MobileTerminalConfigList = await _context.MobileTerminalConfig.Where(a => a.MACAddress.Equals(MACAddress))
                 .ToListAsync();

            if (MobileTerminalConfigList == null)
            {
                responseConfigMobileTerminal = new ResponseConfigMobileTerminal("data not found", 300, null);
                //return NotFound();
            }
            else
            {
                if (MobileTerminalConfigList.Count > 0)
                {
                    responseConfigMobileTerminal = new ResponseConfigMobileTerminal("data found", 200, MobileTerminalConfigList);

                }
                else
                {
                    responseConfigMobileTerminal = new ResponseConfigMobileTerminal("data not found", 300, null);
                }
            }

            return responseConfigMobileTerminal;
        }
    }
}
