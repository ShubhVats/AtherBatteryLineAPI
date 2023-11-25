using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AtherMesRestApi.MESModels;
using AtherMesRestApi.ResponseModel;

using System.Linq;

namespace AtherMesRestApi.Controllers
{
    [Route("api/bugList")]
    [ApiController]
    public class BugListConfigController : ControllerBase
    {
        private readonly MESDBContext _context;

        public BugListConfigController(MESDBContext context)
        {
            _context = context;
        }

        //GET: api/SapOrders/5

        [HttpGet("{line}")]
        public async Task<ActionResult<ResponseConfigBugList>> GetBugWithCreatedby(string line)
        {
            ResponseConfigBugList responseConfigBugList;
            var BugConfigList = await _context.BugListConfig
                 .ToListAsync();

            if (BugConfigList  == null)
            {
                responseConfigBugList = new ResponseConfigBugList("data not found", 300, null);
                //return NotFound();
            }
            else
            {
                if (BugConfigList.Count > 0)
                {
                    responseConfigBugList = new ResponseConfigBugList("data found", 200, BugConfigList);

                }
                else
                {
                    responseConfigBugList = new ResponseConfigBugList("data not found", 300, null);
                }

            }

            return responseConfigBugList;
        }
    }
}
