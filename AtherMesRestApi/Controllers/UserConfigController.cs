//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using AtherMesRestApi.MESModels;
//using AtherMesRestApi.ResponseModel;
//using System.Linq;

//namespace AtherMesRestApi.Controllers
//{
//    [ApiExplorerSettings(IgnoreApi = true)]
//    [Route("api/userconfigservice")]
//    [ApiController]
//    public class UserConfigController : ControllerBase
//    {
//        private readonly MESDBContext _context;

//        public UserConfigController(MESDBContext context)
//        {
//            _context = context;
//        }

//        //GET: api/SapOrders/5
//        [HttpGet("{role}/{line}/{station}")]
//        public async Task<ActionResult<ResponseConfigUser>> GetUserWithRoleLineStation(string role, string line, string station)
//        {
//            ResponseConfigUser responseConfigUser;
//            var UserConfigList = await _context.UserConfig.Where(a => a.UserRole.Equals(role) && a.LineId.Equals(line) && a.StationId.Equals(station))
//                 .ToListAsync();

//            if (UserConfigList == null)
//            {
//                responseConfigUser = new ResponseConfigUser("data not found", 300, null);
//                //return NotFound();
//            }
//            else
//            {
//                responseConfigUser = new ResponseConfigUser("data found", 200, UserConfigList);
//            }

//            return responseConfigUser;
//        }
//    }
//}
