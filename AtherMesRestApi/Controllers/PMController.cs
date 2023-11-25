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
    [Route("api/PM")]
    [ApiController]
    public class PMController : ControllerBase
    {
        private readonly MESDBContext _context;

        public PMController(MESDBContext context)
        {
            _context = context;
        }

        //GET: api/SapOrders/5
        [HttpGet("checklist/{assignedUser}/{line}")]
        public async Task<ActionResult<ResponsePMChecklist>> GetPMCheckList(string assignedUser, string line)
        {
            ResponsePMChecklist response;
            List<PMPhaseList> phaseList = new List<PMPhaseList>();

            if (assignedUser.Equals("Supervisor"))
            {
                for (int i = 1; i < 4; i++)
                {
                    var checkList = await _context.PMCheckList.Where(a => a.Phase.Equals(i))
                         .ToListAsync();
                    Console.WriteLine(checkList.ToString());
                    if (checkList != null && checkList.Count > 0)
                    {
                        phaseList.Add(new PMPhaseList(i.ToString(), checkList));
                    }
                }
            }
            else
            {
                for (int i = 1; i < 4; i++)
                {
                    var checkList = await _context.PMCheckList.Where(a => a.Phase.Equals(i) && a.Status != 6 && a.AssignedUser.Equals(assignedUser))
                         .ToListAsync();
                    Console.WriteLine(checkList.ToString());
                    if (checkList != null && checkList.Count > 0)
                    {
                        phaseList.Add(new PMPhaseList(i.ToString(), checkList));
                    }
                }
            }


            if (phaseList == null)
            {
                response = new ResponsePMChecklist("data not found", 300, null);
                //return NotFound();
            }
            else
            {
                if (phaseList.Count > 0)
                {
                    response = new ResponsePMChecklist("data found", 200, phaseList);

                }
                else
                {
                    response = new ResponsePMChecklist("data not found", 300, null);
                }
            }

            return response;
        }

        [HttpGet("checklist/approve/{assignedUser}/{line}")]
        public async Task<ActionResult<ResponsePMChecklist>> GetPMCheckListApprove(string assignedUser, string line)
        {
            ResponsePMChecklist response;
            List<PMPhaseList> phaseList = new List<PMPhaseList>();
            if (assignedUser.Equals("Supervisor"))
            {
                for (int i = 1; i < 4; i++)
                {
                    var checkList = await _context.PMCheckList.Where(a => a.Phase.Equals(i) && a.Status == 5)
                         .ToListAsync();
                    if (checkList != null && checkList.Count > 0)
                    {
                        phaseList.Add(new PMPhaseList(i.ToString(), checkList));
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
            //            phaseList.Add(new PMPhaseList(i.ToString(), checkList));
            //        }
            //    }
            //}


            if (phaseList == null)
            {
                response = new ResponsePMChecklist("data not found", 300, null);
                //return NotFound();
            }
            else
            {
                if (phaseList.Count > 0)
                {
                    response = new ResponsePMChecklist("data found", 200, phaseList);

                }
                else
                {
                    response = new ResponsePMChecklist("data not found", 300, null);
                }
            }

            return response;
        }

        [HttpGet("checkpoint/{checklistid}/{line}")]
        public async Task<ActionResult<ResponsePMCheckPoint>> GetPMCheckPoint(int checklistid, string line)
        {
            ResponsePMCheckPoint response;
            var checkList = await _context.PMCheckPoint.Where(a => a.CheckListID.Equals(checklistid))
                 .ToListAsync();

            if (checkList == null)
            {
                response = new ResponsePMCheckPoint("data not found", 300, null);
                //return NotFound();
            }
            else
            {
                if (checkList.Count > 0)
                {
                    response = new ResponsePMCheckPoint("data found", 200, checkList);

                }
                else
                {
                    response = new ResponsePMCheckPoint("data not found", 300, null);
                }
            }

            return response;
        }

        [HttpPost("checkpointsaveclose")]
        public async Task<ActionResult<ResponseSave>> saveclosePMCheckPoint(List<IPQCSaveCloseString> ipqcSaveStringList)
        {
            ResponseSave response;
            string status = string.Empty;

            var instance = checkInstanceNumberAsyncList(ipqcSaveStringList);

            foreach (IPQCSaveCloseString ipqcSaveString in ipqcSaveStringList)
            {
                PMSaveClose saveClose = new PMSaveClose(Int32.Parse(ipqcSaveString.CheckListId), ipqcSaveString.CheckPointId, Int32.Parse(ipqcSaveString.CheckPointStatus), ipqcSaveString.CheckPointValue, ipqcSaveString.Remark,instance.Result.Instance);
                Console.WriteLine(saveClose.ToString());
                var ipqcList = await _context.PMSaveClose.Where(a => a.CheckListId.Equals(saveClose.CheckListId) && a.CheckPointId.Equals(saveClose.CheckPointId)).ToListAsync();
               if (ipqcList.Count > 0)
                {
                    ipqcList.ForEach(a => a.CheckPointStatus = saveClose.CheckPointStatus);
                    ipqcList.ForEach(a => a.CheckPointValue = saveClose.CheckPointValue);
                    ipqcList.ForEach(a => a.Remark = saveClose.Remark);
                    ipqcList.ForEach(a => a.Instance = saveClose.Instance);
                    Console.WriteLine(ipqcList.ToString());

                    await _context.SaveChangesAsync();
                    status = "Success";

                }
                else
                {
                    _context.PMSaveClose.Add(saveClose);
                    await _context.SaveChangesAsync();
                    status = "Success";

                }

            }
            if (status == "Success")
            {
                var schedule = await _context.Config_PMSchedule.Where(a => a.CheckListId.Equals(Int32.Parse(ipqcSaveStringList[0].CheckListId))).ToListAsync();
                if (schedule.Count > 0)
                {
                    if (ipqcSaveStringList[0].CheckPointStatus.Equals("2"))
                    {
                        schedule.ForEach(a => a.Status = 5);
                    }
                    else if (ipqcSaveStringList[0].CheckPointStatus.Equals("3"))
                    {

                    }
                    else
                    {
                        schedule.ForEach(a => a.Status = 4);
                    }
                    await _context.SaveChangesAsync();
                    status = "Success";

                }

                Maint_History_PMCheckList quality_History = new(Convert.ToDateTime(ipqcSaveStringList[0].CompletonDateTime), Convert.ToDateTime(ipqcSaveStringList[0].CompletonDateTime), ipqcSaveStringList[0].ProdShift, Int32.Parse(ipqcSaveStringList[0].CheckListId), ipqcSaveStringList[0].UserId, 4,instance.Result.Instance);
                _context.Maint_History_PMCheckList.Add(quality_History);
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

            ResponseIPQCVal parameterValue;
            var parameter = await _context.PMSaveClose.Where(a => a.CheckListId.Equals(checklistid) && a.CheckPointId.Equals(checkpointid)).ToListAsync();

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

        [HttpGet("supervisor/{checklistid}/{assignedUser}")]
        public async Task<ActionResult<ResponseSave>> updateIPQCCheckList(int checklistid, string assignedUser)
        {
            ResponseSave response;
            string Status = string.Empty;

            var schedule = await _context.Config_PMSchedule.Where(a => a.CheckListId.Equals(checklistid)).ToListAsync();
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
        public async Task<ActionResult<ResponseSave>> updateIPQCCheckListStatus(int checklistid, int status, DateTime completondatetime,string prodshift, string userid)
        {
            ResponseSave response;
            string Status = string.Empty;
            Config_Instance_PM instance = new Config_Instance_PM(0, 0);
            instance = await _context.Config_Instance_PM.Where(a => a.CheckListId.Equals(checklistid)).FirstOrDefaultAsync();
            var instanceNumber = instance.Instance;
            instance.Instance++;

            var schedule = await _context.Config_PMSchedule.Where(a => a.CheckListId.Equals(checklistid)).ToListAsync();
            Console.WriteLine(schedule.Count);
            schedule.ForEach(a => a.Status = status);
            schedule.ForEach(a => a.CompletonDateTime = completondatetime);
            await _context.SaveChangesAsync();
            Status = "Success";

            if (Status == "Success")
            {
                Maint_History_PMCheckList quality_History = new(completondatetime, completondatetime, prodshift, checklistid, userid, status,instanceNumber);
                _context.Maint_History_PMCheckList.Add(quality_History);
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

        [HttpGet("maintenance/getall")]
        public async Task<ActionResult<ResponseVMaintBreakdownLog>> maintenancegetall()
        {
            ResponseVMaintBreakdownLog response;
            var List = await _context.v_Maint_Breakdown_Log.Where(a => a.Status != 3 && a.TotalBDTime > 60).OrderByDescending(i=>i.TotalBDTime)
                 .ToListAsync();
            List<v_Maint_Breakdown_Log> categoryList = new List<v_Maint_Breakdown_Log>(List.OrderBy(j => j.StationId));
            if (categoryList == null)
            {
                response = new ResponseVMaintBreakdownLog("data not found", 300, null);
                //return NotFound();
            }
            else
            {
                if (categoryList.Count > 0)
                {
                    response = new ResponseVMaintBreakdownLog("data found", 200, categoryList);

                }
                else
                {
                    response = new ResponseVMaintBreakdownLog("No new Breakdown!", 300, null);
                }
            }

            return response;
        }

        [HttpPost("maintenance/update")]
        public async Task<ActionResult<ResponseSave>> maintenanceupdate(List<Maint_Breakdown_Log_Input> logs)
        {
            string status = string.Empty;
            ResponseSave responseSave;

            try
            {
                foreach (Maint_Breakdown_Log_Input log in logs)
                {
                    var batteryDetailsRejection = await _context.Maint_Breakdown_Log.Where(a => a.BreakdownID.Equals(Int32.Parse(log.BreakdownID))).ToListAsync();
                    batteryDetailsRejection.ForEach(a => a.BDRemark = log.BDRemark);
                    batteryDetailsRejection.ForEach(a => a.Status = int.Parse(log.Status));
                    await _context.SaveChangesAsync();

                }

            }
            catch (Exception ex)
            {
                status = "Failed";
                Console.WriteLine(ex.Message);
            }

            status = "Success";
            if (status == "Success")
            {
                responseSave = new ResponseSave("Data saved successfully!", 200);
            }
            else
            {
                responseSave = new ResponseSave("Data not saved.", 300);
            }

            return responseSave;
        }

        //[HttpPost("supervisor/saveclose")]
        //public async Task<ActionResult<ResponseSave>> savecloseIPQCCheckPoint(IPQCSaveCloseString ipqcSaveStringList)
        //{


        //    ResponseSave response;
        //    string status = string.Empty;
        //    String Error = "";

            

        //    try
        //    {
        //        PMSaveClose saveClose = new PMSaveClose(Int32.Parse(ipqcSaveStringList.CheckListId), ipqcSaveStringList.CheckPointId, Int32.Parse(ipqcSaveStringList.CheckPointStatus), ipqcSaveStringList.CheckPointValue, ipqcSaveStringList.Remark);
        //        var ipqcList = await _context.PMSaveClose.Where(a => a.CheckListId.Equals(saveClose.CheckListId) && a.CheckPointId.Equals(saveClose.CheckPointId)).ToListAsync();
        //        if (ipqcList.Count > 0)
        //        {
        //            //ipqcList.ForEach(a => a.CheckPointStatus = saveClose.CheckPointStatus);
        //            ipqcList.ForEach(a => a.CheckPointValue = saveClose.CheckPointValue);
        //            ipqcList.ForEach(a => a.Remark = saveClose.Remark);

        //            await _context.SaveChangesAsync();
        //            status = "Success";

        //        }
        //        else
        //        {
        //            _context.PMSaveClose.Add(saveClose);
        //            await _context.SaveChangesAsync();
        //            status = "Success";

        //        }

        //    }

        //    catch (Exception e)
        //    {
        //        status = "Failed" + e;
        //        Console.WriteLine(status);
        //        Error = e.Message.ToString();
        //    }

        //    if (status == "Success")
        //    {
        //        response = new ResponseSave("Data updated successfully!", 200);
        //    }
        //    else
        //    {
        //        response = new ResponseSave("Data not updated. Error : " + Error, 300);
        //    }


        //    return response;
        //}
        private async Task<Config_Instance_PM> checkInstanceNumberAsyncList(List<IPQCSaveCloseString> ipqcSaveStringList)
        {
            var instance = await _context.Config_Instance_PM.Where(a => a.CheckListId.Equals(Int32.Parse(ipqcSaveStringList[0].CheckListId))).FirstOrDefaultAsync();

            if (instance == null)
            {
                _context.Config_Instance_PM.Add(new Config_Instance_PM(Int32.Parse(ipqcSaveStringList[0].CheckListId), 1));
                await _context.SaveChangesAsync();
                return new Config_Instance_PM(0, 1);
            }
            return instance;
        }

    }

}


