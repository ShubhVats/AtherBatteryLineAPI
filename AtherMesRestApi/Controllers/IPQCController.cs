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
    [Route("api/ipqc")]
    [ApiController]
    public class IPQCController : ControllerBase
    {
        private readonly MESDBContext _context;

        public IPQCController(MESDBContext context)
        {
            _context = context;
        }


        [HttpGet("checklist/{assignedUser}/{line}")]
        public async Task<ActionResult<ResponseCheckList>> GetIPQCheckList(string assignedUser, string line)
        {
            ResponseCheckList response;
            List<IPQCPhaseChecklist> phaseList = new List<IPQCPhaseChecklist>();
            if (assignedUser.Equals("Supervisor"))
            {
                for (int i = 1; i < 4; i++)
                {
                    var checkList = await _context.CheckList.Where(a => a.Phase.Equals(i.ToString()))
                         .ToListAsync();
                    if (checkList != null && checkList.Count > 0)
                    {
                        phaseList.Add(new IPQCPhaseChecklist(i.ToString(), checkList));
                    }
                }
            }
            else
            {
                for (int i = 1; i < 4; i++)
                {
                    var checkList = await _context.CheckList.Where(a => a.Phase.Equals(i.ToString()) && a.Status != 6 && a.AssignedUser.Equals(assignedUser))
                         .ToListAsync();
                    if (checkList != null && checkList.Count > 0)
                    {
                        phaseList.Add(new IPQCPhaseChecklist(i.ToString(), checkList));
                    }
                }
            }


            if (phaseList == null)
            {
                response = new ResponseCheckList("data not found", 300, null);
                //return NotFound();
            }
            else
            {
                if (phaseList.Count > 0)
                {
                    response = new ResponseCheckList("data found", 200, phaseList);

                }
                else
                {
                    response = new ResponseCheckList("data not found", 300, null);
                }
            }

            return response;
        }

        [HttpGet("checklist/approve/{assignedUser}/{line}")]
        public async Task<ActionResult<ResponseCheckList>> GetIPQCheckListApprove(string assignedUser, string line)
        {
            ResponseCheckList response;
            List<IPQCPhaseChecklist> phaseList = new List<IPQCPhaseChecklist>();
            if (assignedUser.Equals("Supervisor"))
            {
                for (int i = 1; i < 4; i++)
                {
                    var checkList = await _context.CheckList.Where(a => a.Phase.Contains(i.ToString()))
                         .ToListAsync();
                    if (checkList != null && checkList.Count > 0)
                    {
                        phaseList.Add(new IPQCPhaseChecklist(i.ToString(), checkList));
                    }
                }
            }
            //else
            //{
            //    for (int i = 1; i < 4; i++)
            //    {
            //        var checkList = await _context.CheckList.Where(a => a.Phase.Equals(i.ToString()) && a.Status != 4 && a.Status != 5 && a.AssignedUser.Equals(assignedUser))
            //             .ToListAsync();
            //        if (checkList != null && checkList.Count > 0)
            //        {
            //            phaseList.Add(new IPQCPhaseChecklist(i.ToString(), checkList));
            //        }
            //    }
            //}


            if (phaseList == null)
            {
                response = new ResponseCheckList("data not found", 300, null);
                //return NotFound();
            }
            else
            {
                if (phaseList.Count > 0)
                {
                    response = new ResponseCheckList("data found", 200, phaseList);

                }
                else
                {
                    response = new ResponseCheckList("data not found", 300, null);
                }
            }

            return response;
        }


        [HttpGet("checkpoint/{checklistid}/{line}")]
        public async Task<ActionResult<ResponseCheckPoint>> GetIPQCCheckPoint(int checklistid, string line)
        {
            ResponseCheckPoint response;
            var checkList = await _context.CheckPoint.Where(a => a.CheckListID.Equals(checklistid)).OrderBy(a => a.StationID).OrderBy(a => a.CheckPointId)
                 .ToListAsync();

            if (checkList == null)
            {
                response = new ResponseCheckPoint("data not found", 300, null);
                //return NotFound();
            }
            else
            {
                if (checkList.Count > 0)
                {
                    response = new ResponseCheckPoint("data found", 200, checkList);

                }
                else
                {
                    response = new ResponseCheckPoint("data not found", 300, null);
                }
            }

            return response;
        }




        [HttpGet("v1/checkpoint/{checklistid}")]
        public async Task<ActionResult<ResponseCheckPoints>> GetIPQCCheckPoints(int checklistid)
        {
            ResponseCheckPoints response;
            var checkList = await _context.CheckPoints.Where(a => a.CheckListID.Equals(checklistid)).OrderBy(a => a.StationID).OrderBy(a => a.CheckPointId)
                 .ToListAsync();

            if (checkList == null)
            {
                response = new ResponseCheckPoints("data not found", 300, null);
                //return NotFound();
            }
            else
            {
                if (checkList.Count > 0)
                {
                    response = new ResponseCheckPoints("data found", 200, checkList);

                }
                else
                {
                    response = new ResponseCheckPoints("data not found", 300, null);
                }
            }

            return response;
        }

        [HttpPost("checkpointsaveclose")]
        public async Task<ActionResult<ResponseSave>> savecloseIPQCCheckPoint(List<IPQCSaveCloseString> ipqcSaveStringList)
        {
            ResponseSave response;
            string status = string.Empty;

            var instance = checkInstanceNumberAsyncList(ipqcSaveStringList);

            foreach (IPQCSaveCloseString ipqcSaveString in ipqcSaveStringList)
            {


                //Save Points
                IPQCSaveClose saveClose = new IPQCSaveClose(Int32.Parse(ipqcSaveString.CheckListId), ipqcSaveString.CheckPointId, Int32.Parse(ipqcSaveString.CheckPointStatus), ipqcSaveString.CheckPointValue, ipqcSaveString.Remark, instance.Result.Instance);

                var ipqcList = await _context.IPQCSaveClose.Where(a => a.CheckListId.Equals(saveClose.CheckListId) && a.CheckPointId.Equals(saveClose.CheckPointId)).ToListAsync();
                if (ipqcList.Count > 0)
                {
                    ipqcList.ForEach(a => a.CheckPointStatus = saveClose.CheckPointStatus);
                    ipqcList.ForEach(a => a.CheckPointValue = saveClose.CheckPointValue);
                    ipqcList.ForEach(a => a.Remark = saveClose.Remark);
                    ipqcList.ForEach(a => a.Instance = saveClose.Instance);

                    await _context.SaveChangesAsync();
                    status = "Success";

                }
                else
                {
                    _context.IPQCSaveClose.Add(saveClose);
                    await _context.SaveChangesAsync();
                    status = "Success";

                }


            }
            if (status == "Success")
            {
                //update schedule
                var schedule = await _context.Config_IPQCSchedule.Where(a => a.CheckListId.Equals(Int32.Parse(ipqcSaveStringList[0].CheckListId))).ToListAsync();
                if (schedule.Count > 0)
                {
                    if (ipqcSaveStringList[0].CheckPointStatus.Equals("2"))
                    {
                        schedule.ForEach(a => a.Status = 5);
                    }
                    else
                    {
                        schedule.ForEach(a => a.Status = 4);
                    }

                    schedule.ForEach(a => a.DueDateTime = Convert.ToDateTime(ipqcSaveStringList[0].CompletonDateTime));
                    await _context.SaveChangesAsync();
                    status = "Success";
                }


                //Create History
                Quality_History_IPQCCheckList quality_History = new(Convert.ToDateTime(ipqcSaveStringList[0].CompletonDateTime), Convert.ToDateTime(ipqcSaveStringList[0].CompletonDateTime), ipqcSaveStringList[0].ProdShift, Int32.Parse(ipqcSaveStringList[0].CheckListId), ipqcSaveStringList[0].UserId, 4,instance.Result.Instance);
                _context.Quality_History_IPQCCheckList.Add(quality_History);
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


        [HttpGet("checkval/{checklistid}/{checkpointid}")]
        public async Task<ActionResult<ResponseIPQCVal>> GetIPQCCheckPointVal(int checklistid, string checkpointid)
        {
            string checkValue = "", remark = "";

            ResponseIPQCVal parameterValue = new ResponseIPQCVal();
            var parameter = await _context.IPQCSaveClose.Where(a => a.CheckListId.Equals(checklistid) && a.CheckPointId.Equals(checkpointid)).ToListAsync();

            checkValue = parameter[parameter.Count - 1].CheckPointValue;
            remark = parameter[parameter.Count - 1].Remark;
            IPQCVal val = new IPQCVal(checkValue, remark);

            if (parameter.Count() == 0)
            {
                parameterValue = new ResponseIPQCVal("data not found", 300, null);
                //return NotFound();
            }
            else
            {
                parameterValue = new ResponseIPQCVal("data found", 200, val);
            }

            return parameterValue;

        }

        [HttpPost("checkallval")]
        public async Task<ActionResult<ResponseAllParameterValue>> GetIPQCCheckPointAllVal(CheckpointsVals checkpoints)
        {

            ResponseAllParameterValue parameterValue;
            List<string> responseData = new List<string>();

            try
            {
                for (int i = 0; i < checkpoints.fields.Count(); i++)
                {
                    Console.WriteLine(checkpoints.fields[i].CheckList);
                    Console.WriteLine(checkpoints.fields[i].CheckPoint);

                    var parameter = await _context.IPQCSaveClose.Where(a => a.CheckListId.Equals(checkpoints.fields[i].CheckList) && a.CheckPointId.Equals(checkpoints.fields[i].CheckPoint)).FirstAsync();

                    Console.WriteLine(parameter.ToString());
                    Console.WriteLine(parameter.CheckPointValue);
                    //if()
                    responseData.Add(parameter.CheckPointValue);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            if (responseData.Count() == 0)
            {
                parameterValue = new ResponseAllParameterValue("data not found", 300, null);
                //return NotFound();
            }
            else
            {
                parameterValue = new ResponseAllParameterValue("data found", 200, responseData);
            }

            return parameterValue;

        }

        [HttpGet("supervisor/{checklistid}/{assignedUser}")]
        public async Task<ActionResult<ResponseSave>> updateIPQCCheckList(int checklistid, string assignedUser)
        {
            ResponseSave response;
            string Status = string.Empty;

            var schedule = await _context.Config_IPQCSchedule.Where(a => a.CheckListId.Equals(checklistid)).ToListAsync();
            Console.WriteLine(schedule.Count);
            schedule.ForEach(a => a.AssignedUser = assignedUser);
            await _context.SaveChangesAsync();
            Status = "Success";

            if (Status == "Success")
            {
                response = new ResponseSave("Data saved successfully!", 200);
            }
            else
            {
                response = new ResponseSave("Data not saved.", 300);
            }

            return response;
        }

        [HttpGet("supervisor/{checklistid}/{status}/{completondatetime}/{prodshift}/{userid}")]
        public async Task<ActionResult<ResponseSave>> updateIPQCCheckListStatus(int checklistid, int status, DateTime completondatetime, string prodshift, string userid)
        {
            ResponseSave response;
            string Status = string.Empty;
            Config_Instance instance = new Config_Instance(0,0);
            
            instance = await _context.Config_Instance.Where(a => a.CheckListId.Equals(checklistid)).FirstOrDefaultAsync();
            int instanceNumber = instance.Instance;
            instance.Instance++;


            var schedule = await _context.Config_IPQCSchedule.Where(a => a.CheckListId.Equals(checklistid)).ToListAsync();
            Console.WriteLine(schedule.Count);
            schedule.ForEach(a => a.Status = status);
            schedule.ForEach(a => a.CompletonDateTime = completondatetime);
            await _context.SaveChangesAsync();
            Status = "Success";

            if (Status == "Success")
            {
                Quality_History_IPQCCheckList quality_History = new(completondatetime, completondatetime, prodshift, checklistid, userid, status,instanceNumber);
                _context.Quality_History_IPQCCheckList.Add(quality_History);
                await _context.SaveChangesAsync();
                Status = "Success";

            }

            if (Status == "Success")
            {
                response = new ResponseSave("Data saved successfully!", 200);
            }
            else
            {
                response = new ResponseSave("Data not saved.", 300);
            }

            return response;
        }


        [HttpPost("supervisor/saveclose")]
        public async Task<ActionResult<ResponseSave>> savecloseIPQCCheckPoint(IPQCSaveCloseString ipqcSaveStringList)
        {


            ResponseSave response;
            string status = string.Empty;
            String Error = "";


            try
            {
                IPQCSaveClose saveClose = new IPQCSaveClose(Int32.Parse(ipqcSaveStringList.CheckListId), ipqcSaveStringList.CheckPointId, Int32.Parse(ipqcSaveStringList.CheckPointStatus), ipqcSaveStringList.CheckPointValue, ipqcSaveStringList.Remark, 0);

                var ipqcList = await _context.IPQCSaveClose.Where(a => a.CheckListId.Equals(saveClose.CheckListId) && a.CheckPointId.Equals(saveClose.CheckPointId)).ToListAsync();

                if (ipqcList.Count > 0)
                {
                    //ipqcList.ForEach(a => a.CheckPointStatus = saveClose.CheckPointStatus);
                    ipqcList.ForEach(a => a.CheckPointValue = saveClose.CheckPointValue);
                    ipqcList.ForEach(a => a.Remark = saveClose.Remark);

                    await _context.SaveChangesAsync();
                    status = "Success";

                }
                else
                {
                    _context.IPQCSaveClose.Add(saveClose);
                    await _context.SaveChangesAsync();
                    status = "Success";

                }
            }

            catch (Exception e)
            {
                status = "Failed" + e;
                Console.WriteLine(status);
                Error = e.Message.ToString();
            }

            if (status == "Success")
            {
                response = new ResponseSave("Data updated successfully!", 200);
            }
            else
            {
                response = new ResponseSave("Data not updated. Error : " + Error, 300);
            }


            return response;
        }

        private async Task<Config_Instance> checkInstanceNumberAsyncList(List<IPQCSaveCloseString> ipqcSaveStringList)
        {
            var instance = await _context.Config_Instance.Where(a => a.CheckListId.Equals(Int32.Parse(ipqcSaveStringList[0].CheckListId))).FirstOrDefaultAsync();

            if (instance == null)
            {
                _context.Config_Instance.Add(new Config_Instance(Int32.Parse(ipqcSaveStringList[0].CheckListId), 1));
                await _context.SaveChangesAsync();
                return new Config_Instance(0, 1);
            }
            return instance;
        }

    }

}


