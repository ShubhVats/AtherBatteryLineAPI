using System.Linq;
using System.Threading.Tasks;
using AtherMesRestApi.MESModels;
using AtherMesRestApi.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AtherMesRestApi.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/userskill")]
    [ApiController]
    public class UserSkillController : Controller
    {
        private readonly MESDBContext _context;

        public UserSkillController(MESDBContext context)
        {
            _context = context;
        }

        //GET: api/SapOrders/5

        [HttpGet("{Role}/{line}")]
        public async Task<ActionResult<ResponseUserSkill>> GetUserWithRoleLineStation(string Role, string line)
        {
            ResponseUserSkill res;
            var UserList = await _context.UserSkill.Where(a => a.UserRole.Equals(Role))
                 .ToListAsync();

            if (UserList == null)
            {
                res = new ResponseUserSkill("data not found", 300, null);
                //return NotFound();
            }
            else
            {
                res = new ResponseUserSkill("data found", 200, UserList);
            }

            return res;
        }
    }
}
