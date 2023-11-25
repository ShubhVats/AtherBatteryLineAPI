using System.Linq;
using System.Threading.Tasks;
using AtherMesRestApi.MESModels;
using AtherMesRestApi.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AtherMesRestApi.Controllers
{

    [Route("api/StationToken")]
    [ApiController]
    public class StationMasterController : Controller
    {

        private readonly MESDBContext _context;

        public StationMasterController(MESDBContext context)
        {
            _context = context;
        }

        //GET: api/SapOrders/5
        [HttpGet]
        public async Task<ActionResult<ResponseConfigStation>> GetAllStationToken()
        {
            ResponseConfigStation responseConfigStation;
            var DHCStationlist = await _context.StationMaster.Where(a=>a.StationName.Contains("OP"))
                 .ToListAsync();

            if (DHCStationlist == null)
            {
                responseConfigStation = new ResponseConfigStation("data not found", 300, null);
                //return NotFound();
            }
            else
            {
                responseConfigStation = new ResponseConfigStation("data found", 200, DHCStationlist);
            }

            return responseConfigStation;
        }

        [HttpGet("all")]
        public async Task<ActionResult<ResponseConfigStation>> GetStations()
        {
            ResponseConfigStation responseConfigStation;
            var DHCStationlist = await _context.StationMaster
                 .ToListAsync();

            if (DHCStationlist == null)
            {
                responseConfigStation = new ResponseConfigStation("data not found", 300, null);
                //return NotFound();
            }
            else
            {
                responseConfigStation = new ResponseConfigStation("data found", 200, DHCStationlist);
            }

            return responseConfigStation;
        }


        [HttpPost("put")]
        public async Task<ActionResult<ResponseSave>> UpdateStationToken(StationToken stationToken)
        {
            string status = string.Empty;
            var DHCStationlist = await _context.StationMaster.Where(a => a.StationName.Equals(stationToken.station))
                 .ToListAsync();
            DHCStationlist.ForEach(a => a.Token = stationToken.token);
            await _context.SaveChangesAsync();
            status = "Success";



            ResponseSave response;
            //if (stationToken.userid != null && stationToken.userid != " ")
            //{

            //    //try
            //    //{

            //    //    if (status == "Success")
            //    //    {
            //    //        var Userlist = await _context.Config_User.Where(a => a.UserId.Equals(stationToken.userid))
            //    //             .ToListAsync();
            //    //        Userlist.ForEach(a => a.Token = stationToken.token);
            //    //        await _context.SaveChangesAsync();
            //    //        status = "Success";

            //    //    }
            //    //    else
            //    //    {
            //    //        status = "Failure";
            //    //    }
            //    //}
            //    //catch (DbUpdateException e)
            //    //{
            //    //    status = "Error" + e;
            //    //}
            //}
            if (status == "Success")
            {
                response = new ResponseSave("Data updated successfully!", 200);
            }
            else
            {
                response = new ResponseSave("Data not updated.", 300);
            }

            return response;

        }

    }
}
