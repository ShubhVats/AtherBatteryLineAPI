using System;
using System.Linq;
using System.Threading.Tasks;
using AtherMesRestApi.MESModels;
using AtherMesRestApi.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AtherMesRestApi.Controllers
{
    [Route("api/Production")]
    [ApiController]
    public class ProdExecutionController : ControllerBase
    {
        private readonly MESDBContext _context;

        public ProdExecutionController(MESDBContext context)
        {
            _context = context;
        }

        //GET: api/SapOrders/5
        [HttpGet]
        public async Task<ActionResult<ResponseProdExecute>> GetProdDetails()
        {
            ResponseProdExecute response;

            Prod_ProductionExecution data = new Prod_ProductionExecution();

            //data = await _context.Prod_ProductionExecution
            //    .OrderByDescending(s => s.ProdDate ).FirstOrDefaultAsync();

            data = await _context.Prod_ProductionExecution.Where(a => a.Status.Equals(2))
                .OrderByDescending(s => s.ProdDate).FirstOrDefaultAsync();


            if (data == null)
            {
                response = new ResponseProdExecute("data not found", 300, null);
                //return NotFound();
            }
            else
            {
                if (data != null)
                {
                    response = new ResponseProdExecute("data found", 200, data);

                }
                else
                {
                    response = new ResponseProdExecute("data not found", 300, null);
                }
            }

            return response;
        }

        [HttpGet("{skuid}")]
        public async Task<ActionResult<ResponseProdExecute>> GetProdDetails(string skuid)
        {
            ResponseProdExecute response;

            Prod_ProductionExecution data = new Prod_ProductionExecution();
            string resp = "";
            try
            {

                var revision = await _context.BMS_PCBRevisionControl.Where(a => a.Status.Equals(2) && a.SKU.Equals(skuid))
                    .ToListAsync();


                data = await _context.Prod_ProductionExecution.Where(a => a.Status.Equals(2))
                    .OrderByDescending(s => s.ProdDate).FirstOrDefaultAsync();

                revision.ForEach(a =>
                    {
                        if (a.Part != null)
                        {
                            if (a.Part.Equals("BMS") && a.Revision != null)
                            {
                                data.BMS_Revision = a.Revision;
                            }
                            if (a.Part.Equals("PCBA") && a.Revision != null)
                            {
                                data.PCBA_Revision = a.Revision;
                            }
                        }
                    }
                );

                data.SKUId= skuid;

            }
            catch (Exception e)
            {
                resp = e.Message;
            }

            if (data == null)
            {
                response = new ResponseProdExecute("data not found", 300, null);
                //return NotFound();
            }
            else
            {
                if (data != null)
                {
                    response = new ResponseProdExecute("data found", 200, data);

                }
                else
                {
                    response = new ResponseProdExecute("data not found", 300, null);
                }
            }

            return response;
        }


        //[HttpGet("checkpoint/{checklistid}/{line}")]
        //public async Task<ActionResult<ResponsePMCheckPoint>> GetPMCheckPoint(int checklistid, string line)
        //{
        //    ResponsePMCheckPoint response;
        //    var checkList = await _context.PMCheckPoint.Where(a => a.CheckListID.Equals(checklistid))
        //         .ToListAsync();

        //    if (checkList == null)
        //    {
        //        response = new ResponsePMCheckPoint("data not found", 300, null);
        //        //return NotFound();
        //    }
        //    else
        //    {
        //        if (checkList.Count > 0)
        //        {
        //            response = new ResponsePMCheckPoint("data found", 200, checkList);

        //        }
        //        else
        //        {
        //            response = new ResponsePMCheckPoint("data not found", 300, null);
        //        }
        //    }

        //    return response;
        //}

        //[HttpPost("checkpointsaveclose")]
        //public async Task<ActionResult<ResponseSave>> saveclosePMCheckPoint(List<IPQCSaveCloseString> ipqcSaveStringList)
        //{
        //    ResponseSave response;
        //    string status = string.Empty;

        //    foreach (IPQCSaveCloseString ipqcSaveString in ipqcSaveStringList)
        //    {
        //        PMSaveClose saveClose = new PMSaveClose(Int32.Parse(ipqcSaveString.CheckListId), ipqcSaveString.CheckPointId, Int32.Parse(ipqcSaveString.CheckPointStatus), ipqcSaveString.CheckPointValue, ipqcSaveString.Remark);
        //        Console.WriteLine(saveClose.ToString());
        //        var ipqcList = await _context.PMSaveClose.Where(a => a.CheckListId.Equals(saveClose.CheckListId) && a.CheckPointId.Equals(saveClose.CheckPointId)).ToListAsync();
        //        if (ipqcList.Count > 0)
        //        {
        //            ipqcList.ForEach(a => a.CheckPointStatus = saveClose.CheckPointStatus);
        //            ipqcList.ForEach(a => a.CheckPointValue = saveClose.CheckPointValue);
        //            ipqcList.ForEach(a => a.Remark = saveClose.Remark);
        //            Console.WriteLine(ipqcList.ToString());

        //            await _context.SaveChangesAsync();
        //            status = "Success";

        //        }
        //        else
        //        {
        //            _context.PMSaveClose.Add(saveClose);
        //            await _context.SaveChangesAsync();
        //            status = "Success";

        //        }
        //        if (status == "Success")
        //        {
        //            var schedule = await _context.Config_PMSchedule.Where(a => a.CheckListId.Equals(saveClose.CheckListId)).ToListAsync();
        //            if (schedule.Count > 0)
        //            {
        //                schedule.ForEach(a => a.Status = 4);
        //                await _context.SaveChangesAsync();
        //                status = "Success";

        //            }

        //            Maint_History_PMCheckList quality_History = new(Convert.ToDateTime(ipqcSaveString.CompletonDateTime), Convert.ToDateTime(ipqcSaveString.CompletonDateTime), " ", Int32.Parse(ipqcSaveString.CheckListId), " ", 4);
        //            _context.Maint_History_PMCheckList.Add(quality_History);
        //            await _context.SaveChangesAsync();
        //            status = "Success";
        //        }

        //    }

        //    if (status == "Success")
        //    {
        //        response = new ResponseSave("Data saved successfully!", 200);
        //    }
        //    else
        //    {
        //        response = new ResponseSave("Data not saved.", 300);
        //    }

        //    return response;
        //}

        //[HttpGet("checkval/{checklistid}/{checkpointid}")]
        //public async Task<ActionResult<ResponseParameterValue>> GetIPQCCheckPointVal(int checklistid, string checkpointid)
        //{

        //    ResponseParameterValue parameterValue;
        //    var parameter = await _context.PMSaveClose.Where(a => a.CheckListId.Equals(checklistid) && a.CheckPointId.Equals(checkpointid)).ToListAsync();

        //    if (parameter.Count() == 0)
        //    {
        //        parameterValue = new ResponseParameterValue("data not found", 300, null);
        //        //return NotFound();
        //    }
        //    else
        //    {
        //        parameterValue = new ResponseParameterValue("data found", 200, parameter[parameter.Count - 1].CheckPointValue);
        //    }

        //    return parameterValue;

        //}

        //[HttpGet("supervisor/{checklistid}/{assignedUser}")]
        //public async Task<ActionResult<ResponseSave>> updateIPQCCheckList(int checklistid, string assignedUser)
        //{
        //    ResponseSave response;
        //    string Status = string.Empty;

        //    var schedule = await _context.Config_PMSchedule.Where(a => a.CheckListId.Equals(checklistid)).ToListAsync();
        //    Console.WriteLine(schedule.Count);
        //    schedule.ForEach(a => a.AssignedUser = assignedUser);
        //    await _context.SaveChangesAsync();
        //    Status = "Success";

        //    if (Status == "Success")
        //    {
        //        response = new ResponseSave("Data saved successfully!", 200);
        //    }
        //    else
        //    {
        //        response = new ResponseSave("Data not saved.", 300);
        //    }

        //    return response;
        //}

        //[HttpGet("supervisor/{checklistid}/{status}/{completondatetime}")]
        //public async Task<ActionResult<ResponseSave>> updateIPQCCheckListStatus(int checklistid, int status, DateTime completondatetime)
        //{
        //    ResponseSave response;
        //    string Status = string.Empty;

        //    var schedule = await _context.Config_PMSchedule.Where(a => a.CheckListId.Equals(checklistid)).ToListAsync();
        //    Console.WriteLine(schedule.Count);
        //    schedule.ForEach(a => a.Status = status);
        //    schedule.ForEach(a => a.CompletonDateTime = completondatetime);
        //    await _context.SaveChangesAsync();
        //    Status = "Success";

        //    if (Status == "Success")
        //    {
        //        Maint_History_PMCheckList quality_History = new(completondatetime, completondatetime, " ", checklistid, " ", status);
        //        _context.Maint_History_PMCheckList.Add(quality_History);
        //        await _context.SaveChangesAsync();
        //        Status = "Success";

        //    }

        //    if (Status == "Success")
        //    {
        //        response = new ResponseSave("Data saved successfully!", 200);
        //    }
        //    else
        //    {
        //        response = new ResponseSave("Data not saved.", 300);
        //    }

        //    return response;
        //}

        //[HttpGet("maintenance/getall")]
        //public async Task<ActionResult<ResponseMaintBreakdownLog>> maintenancegetall()
        //{
        //    ResponseMaintBreakdownLog response;
        //    var categoryList = await _context.Maint_Breakdown_Log
        //         .ToListAsync();

        //    if (categoryList == null)
        //    {
        //        response = new ResponseMaintBreakdownLog("data not found", 300, null);
        //        //return NotFound();
        //    }
        //    else
        //    {
        //        if (categoryList.Count > 0)
        //        {
        //            response = new ResponseMaintBreakdownLog("data found", 200, categoryList);

        //        }
        //        else
        //        {
        //            response = new ResponseMaintBreakdownLog("data not found", 300, null);
        //        }
        //    }

        //    return response;
        //}

        //[HttpPost("maintenance/update")]
        //public async Task<ActionResult<ResponseSave>> maintenanceupdate(Maint_Breakdown_Log_Input log)
        //{
        //    string status = string.Empty;
        //    ResponseSave responseSave;

        //    var batteryDetailsRejection = await _context.Maint_Breakdown_Log.Where(a => a.BreakdownID.Equals(int.Parse(log.BreakdownID))).ToListAsync();
        //    batteryDetailsRejection.ForEach(a => a.BDRemark = log.BDRemark);
        //    batteryDetailsRejection.ForEach(a => a.Status = int.Parse(log.Status));
        //    await _context.SaveChangesAsync();

        //    status = "Success";
        //    if (status == "Success")
        //    {
        //        responseSave = new ResponseSave("Data saved successfully!", 200);
        //    }
        //    else
        //    {
        //        responseSave = new ResponseSave("Data not saved.", 300);
        //    }

        //    return responseSave;
        //}

    }
}


