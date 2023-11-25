using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtherMesRestApi.MESModels;
using AtherMesRestApi.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AtherMesRestApi.Controllers
{
    [Route("api/LoggedUser")]
    [ApiController]
    public class LoggedUserController : ControllerBase
    {
        private readonly MESDBContext _context;

        public LoggedUserController(MESDBContext context)
        {
            _context = context;
        }



        [HttpPost("userdetails")]
        public async Task<ActionResult<ResponseSave>> saveUserDetails(LoggedUserInput loggedUserInput)
        {
            ResponseSave response;
            string status = string.Empty;



            LoggedUser saveClose = new LoggedUser(Convert.ToDateTime(loggedUserInput.TimeStamp), Convert.ToDateTime(loggedUserInput.ProDate), loggedUserInput.Shift, loggedUserInput.Line, loggedUserInput.StationNo, loggedUserInput.AssignedUser);
            _context.LoggedUser.Add(saveClose);
            await _context.SaveChangesAsync();
            status = "Success";

            if (status == "Success")
            {
                response = new ResponseSave("Data saved successfully!", 200);
            }
            else
            {
                response = new ResponseSave("Data not saved.", 300);
            }

            return response;
        }

        [HttpPost("multipleuserdetails")]
        public async Task<ActionResult<ResponseSave>> saveMultipleUserDetails(List<Prod_LoggedUserInput> prod_LoggedUserInput)
        {
            ResponseSave response;
            string status = string.Empty;


            foreach (Prod_LoggedUserInput input in prod_LoggedUserInput)
            {
                Prod_LoggedUser saveClose = new Prod_LoggedUser(Convert.ToDateTime(input.Timestamp), Convert.ToDateTime(input.ProdDate), input.Prodshift, input.Department, input.Status, input.StationName, input.AssignedUser);
                _context.Prod_LoggedUser.Add(saveClose);
                await _context.SaveChangesAsync();
                status = "Success";


            }
            if (status == "Success")
            {
                response = new ResponseSave("Data saved successfully!", 200);
            }
            else
            {
                response = new ResponseSave("Data not saved.", 300);
            }

            return response;
        }

        [HttpPost("getusers")]
        public async Task<ActionResult<ResponseUsers>> getMultipleUserDetails(RequestStations requestStations)
        {
            ResponseUsers response;
            List<Stations> stations = requestStations.stations;

            List<string> parentList = new List<string>();
            parentList.Clear();

            

            for (int i = 0; i < stations.Count; i++)
            {
                var GeneologyProdList = await _context.Config_LineUserAssigment.Where(a => a.StationName.Equals(stations[i].station)).FirstOrDefaultAsync();

                if (GeneologyProdList != null)
                {
                    parentList.Add(GeneologyProdList.AssignedUserName);
                }

            }



            if (parentList == null)
            {
                response = new ResponseUsers("data not found", 300, null);
                //return NotFound();
            }
            else
            {
                if (parentList.Count > 0)
                {
                    response = new ResponseUsers("data found", 200, parentList);

                }
                else
                {
                    response = new ResponseUsers("data not found", 300, null);

                }

            }

            return response;
        }

        [HttpGet("assignedusers/{station}")]
        public async Task<ActionResult<ResponseAssignedUsers>> getAssignedUser(string station)
        {
            ResponseAssignedUsers response;
            var userList = await _context.Config_LineUserAssigment
                 .Where(a => a.StationName.Equals(station))
                 .ToListAsync();

            if (userList == null)
            {
                response = new ResponseAssignedUsers("data not found", 300, null);
                //return NotFound();
            }
            else
            {
                if (userList.Count > 0)
                {
                    response = new ResponseAssignedUsers("data found", 200, userList);

                }
                else
                {
                    response = new ResponseAssignedUsers("data not found", 300, null);
                }
            }

            return response;
        }

        [HttpGet("assignedusers/Common/{station}")]
        public async Task<ActionResult<ResponseAssignedUsersCommon>> getAssignedUserCommon(string station)
        {
            ResponseAssignedUsersCommon response;
            List<Config_UserAssigment> uniqueItemsList = new List<Config_UserAssigment>();

            //calling requested station
            var userList = await _context.Config_UserAssigment
                 .Where(a => a.StationName.Equals(station))
                 .ToListAsync();

            //separating unique usernames
            var makes = userList.Select(car => car.UserName).Distinct();

            //calling unique usernames
            foreach (var item in makes)
            {
                Config_UserAssigment userListRes = await _context.Config_UserAssigment
                     .Where(a => a.UserName.Equals(item))
                     .FirstOrDefaultAsync();
                uniqueItemsList.Add(userListRes);

            }


            if (userList == null)
            {
                response = new ResponseAssignedUsersCommon("data not found", 300, null);
                //return NotFound();
            }
            else
            {
                if (userList.Count > 0)
                {
                    response = new ResponseAssignedUsersCommon("data found", 200, uniqueItemsList);

                }
                else
                {
                    response = new ResponseAssignedUsersCommon("data not found", 300, null);
                }
            }

            return response;
        }

        [HttpPost("updateassigneduser")]
        public async Task<ActionResult<ResponseSave>> updateAssignedUser(Config_LineUserAssigmentInput config_LineUsers)
        {
            ResponseSave response;
            string status = string.Empty;


            try
            {

                var data = await _context.Config_LineUserAssigment.Where(a => a.AssignedUserID.Equals(config_LineUsers.AssignedUserID)).Where(a => a.StationName.Equals(config_LineUsers.StationName)).ToListAsync();
                data.ForEach(a => a.Status = int.Parse(config_LineUsers.Status));

                await _context.SaveChangesAsync();
                status = "Success";


            }
            catch (Exception e)
            {
                status = "Failed" + e;
                Console.WriteLine(status);
            }
            if (status == "Success")
            {
                response = new ResponseSave("Data saved successfully!", 200);
            }
            else
            {
                response = new ResponseSave("Data not saved.", 300);
            }

            return response;
        }

        [HttpGet("getconfigusers/{userid}")]
        public async Task<ActionResult<ResponseConfigUserCommon>> getConfigUser(string userid)
        {
            ResponseConfigUserCommon response;
            String Error = "";
            List<v_Config_User_Common> GeneologyProdList = new List<v_Config_User_Common>();

            try
            {
                GeneologyProdList = await _context.v_Config_User_Common.Where(a => a.UserID.Equals(userid)).ToListAsync();
            }
            catch (Exception e)
            {
                Error = e.Message.ToString();
            }
            if (GeneologyProdList == null)
            {
                response = new ResponseConfigUserCommon("Data not found. Error " + Error, 300, null);
            }
            else
            {
                if (GeneologyProdList.Count > 0)
                {
                    response = new ResponseConfigUserCommon("Data found.", 200, GeneologyProdList);
                }
                else
                {
                    response = new ResponseConfigUserCommon("Data not found. " + Error, 300, null);
                }

            }

            return response;
        }

        [HttpPost("updateassignedusersupervisor")]
        public async Task<ActionResult<ResponseSave>> updateAssignedUserSupervisor(Config_LineUserAssigmentInput config_LineUsers)
        {
            ResponseSave response;
            string status = string.Empty;
            String Error = "";

            try
            {

                var data = await _context.Config_LineUserAssigment.Where(a => a.AssignedUserID.Equals(config_LineUsers.AssignedUserIDOld) && a.StationName.Equals(config_LineUsers.StationName)).ToListAsync();
                //var data = await _context.Config_LineUserAssigment.Where(a => a.AssignedUserID.Equals(config_LineUsers.AssignedUserIDOld) && a.StationName.Equals(config_LineUsers.StationNameOld)).ToListAsync();
                data.ForEach(a => a.AssignedUserID = config_LineUsers.AssignedUserID);
                data.ForEach(a => a.AssignedUserName = config_LineUsers.AssignedUserName);
                //data.ForEach(a => a.Status = int.Parse(config_LineUsers.Status));

                await _context.SaveChangesAsync();
                status = "Success";


            }
            catch (Exception e)
            {
                Error = e.Message.ToString();
                status = "Failed" + e;
                Console.WriteLine(status);
            }
            if (status == "Success")
            {
                response = new ResponseSave("Data saved successfully!", 200);
            }
            else
            {
                response = new ResponseSave("Data not saved. Error : " + Error, 300);
            }

            return response;
        }

        [HttpPost("addassignedusersupervisor")]
        public async Task<ActionResult<ResponseSave>> AddAssignedUserSupervisor(Config_LineUserAssigmentInput config_LineUsers)
        {
            ResponseSave response;
            string status = string.Empty;

            String Error = "";

            try
            {

                Config_LineUserAssigment item = new Config_LineUserAssigment(DateTime.Parse(config_LineUsers.Timestamp), DateTime.Parse(config_LineUsers.ProdDate), config_LineUsers.ProdShift, config_LineUsers.StationName, config_LineUsers.AssignedUserID, config_LineUsers.AssignedUserName, Int32.Parse(config_LineUsers.Detartment), Int32.Parse(config_LineUsers.UserRole), Int32.Parse(config_LineUsers.Status));

                _context.Config_LineUserAssigment.Add(item);
                await _context.SaveChangesAsync();
                status = "Success";


            }
            catch (Exception e)
            {
                status = "Failed" + e;
                Console.WriteLine(status);
                Error = e.Message.ToString();
            }
            if (status == "Success")
            {
                response = new ResponseSave("Data saved successfully!", 200);
            }
            else
            {
                response = new ResponseSave("Data not saved. Error : " + Error, 300);
            }

            return response;
        }

        [HttpGet("allassignedusers")]
        public async Task<ActionResult<ResponseAssignedUsers>> AllAssignedUsers()
        {
            ResponseAssignedUsers response;
            List<Config_LineUserAssigment> userList = new List<Config_LineUserAssigment>();
            String Error = "";

            try
            {
                userList = await _context.Config_LineUserAssigment
                     .ToListAsync();

            }
            catch (Exception e)
            {
                Error = e.Message.ToString();
            }

            if (userList == null)
            {
                response = new ResponseAssignedUsers("Data not found. Error: " + Error, 300, null);
            }
            else
            {
                if (userList.Count > 0)
                {
                    response = new ResponseAssignedUsers("Data found.", 200, userList);

                }
                else
                {
                    response = new ResponseAssignedUsers("Data not found.", 300, null);
                }
            }

            return response;
        }
    }
}


