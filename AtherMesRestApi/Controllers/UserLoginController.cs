using System.Linq;
using System.Threading.Tasks;
using AtherMesRestApi.MESModels;
using AtherMesRestApi.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AtherMesRestApi.Controllers
{
    [Route("api/UserLogin")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private readonly MESDBContext _context;

        public UserLoginController(MESDBContext context)
        {
            _context = context;
        }


        [HttpGet("getallusers/{station}/{role}/{line}")]
        public async Task<ActionResult<ResponseUserLogin>> getUser(string station, string role, string line)
        {
            ResponseUserLogin response;
            var userList = await _context.UserLogin
                 .Where(a => a.StationName.Equals(station) && a.User_Role.Equals(role))
                 .ToListAsync();

            if (userList == null)
            {
                response = new ResponseUserLogin("data not found", 300, null);
                //return NotFound();
            }
            else
            {
                if (userList.Count > 0)
                {
                    response = new ResponseUserLogin("data found", 200, userList);

                }
                else
                {
                    response = new ResponseUserLogin("data not found", 300, null);
                }
            }

            return response;
        }

        [HttpPost("updateuser")]
        public async Task<ActionResult<string>> postUser(UserLogin userLogin)
        {
            var userList = await _context.UserLogin.Where(a => a.StationId.Equals(userLogin.StationId) && a.UserID.Equals(userLogin.UserID))
                 .ToListAsync();
            userList.ForEach(a => a.Token = userLogin.Token);
            string status = string.Empty;

            try
            {
                await _context.SaveChangesAsync();
                status = "Success";

            }
            catch (DbUpdateException e)
            {
                status = "Error" + e;
                return status;
            }
            return status;
        }

    }
}
