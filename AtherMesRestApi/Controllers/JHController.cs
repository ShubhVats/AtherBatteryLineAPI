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
    [Route("api/jh")]
    [ApiController]
    public class JHController : ControllerBase
    {
        private readonly MESDBContext _context;

        public JHController(MESDBContext context)
        {
            _context = context;
        }


        //GET: api/SapOrders/5
        [HttpGet("checklist/{stationid}/{line}")]
        public async Task<ActionResult<ResponseJHChecklist>> GetJHcheckList(int stationid, string line)
        {
            ResponseJHChecklist response;
            List<JHCheckList> phaseList = new List<JHCheckList>();
            try
            {
                phaseList = await _context.JHCheckList.Where(a => a.StationId.Equals(stationid) && a.Status != 4 && a.Status != 5)
                 .ToListAsync();
                Console.WriteLine(phaseList.ToString());
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
            }

            if (phaseList == null)
            {
                response = new ResponseJHChecklist("data not found", 300, null);
                //return NotFound();
            }
            else
            {
                if (phaseList.Count > 0)
                {
                    response = new ResponseJHChecklist("data found", 200, phaseList);

                }
                else
                {
                    response = new ResponseJHChecklist("data not found", 300, null);
                }
            }

            return response;


        }

        [HttpGet("checkpoint/{checklistid}/{line}")]
        public async Task<ActionResult<ResponseJHCheckPoint>> GetJHCheckPoint(int checklistid, string line)
        {
            ResponseJHCheckPoint response;
            var checkList = await _context.Config_JHCheckPoint.Where(a => a.CheckListId.Equals(checklistid))
                 .ToListAsync();
            Console.WriteLine(checkList.ToString());

            if (checkList == null)
            {
                response = new ResponseJHCheckPoint("data not found", 300, null);
                //return NotFound();
            }
            else
            {
                if (checkList.Count > 0)
                {
                    response = new ResponseJHCheckPoint("data found", 200, checkList);

                }
                else
                {
                    response = new ResponseJHCheckPoint("data not found", 300, null);
                }
            }

            return response;
        }

        [HttpPost("checkpointsaveclose")]
        public async Task<ActionResult<ResponseSave>> saveclosePMCheckPoint(List<JHStringSaveClose> JHSaveStringList)
        {
            ResponseSave response;
            string status = string.Empty;

            foreach (JHStringSaveClose JHSaveString in JHSaveStringList)
            {
                Prod_Execute_JHCheckList saveClose = new(Int32.Parse(JHSaveString.CheckListId), JHSaveString.CheckPointId, Int32.Parse(JHSaveString.CheckPointStatus), JHSaveString.CheckPointValue, JHSaveString.Remark);
                Console.WriteLine(saveClose.ToString());
                var ipqcList = await _context.Prod_Execute_JHCheckList.Where(a => a.CheckListId.Equals(saveClose.CheckListId) && a.CheckPointId.Equals(saveClose.CheckPointId)).ToListAsync();
                if (ipqcList.Count > 0)
                {
                    ipqcList.ForEach(a => a.CheckPointStatus = saveClose.CheckPointStatus);
                    ipqcList.ForEach(a => a.CheckPointValue = saveClose.CheckPointValue);
                    ipqcList.ForEach(a => a.Remark = saveClose.Remark);
                    Console.WriteLine(ipqcList.ToString());

                    await _context.SaveChangesAsync();
                    status = "Success";

                }
                else
                {
                    _context.Prod_Execute_JHCheckList.Add(saveClose);
                    await _context.SaveChangesAsync();
                    status = "Success";

                }
           
            }
            if (status == "Success")
            {
                var schedule = await _context.Config_JHSchedule.Where(a => a.CheckListID.Equals(Int32.Parse(JHSaveStringList[0].CheckListId))).ToListAsync();
                if (schedule.Count > 0)
                {
                    if (JHSaveStringList[0].CheckPointStatus.Equals("2"))
                    {
                        schedule.ForEach(a => a.Status = 5);
                    }
                    else
                    {
                        schedule.ForEach(a => a.Status = 5);
                    }

                    schedule.ForEach(a => a.DueDateTime = DateTime.Now.Date);
                    await _context.SaveChangesAsync();
                    status = "Success";
                }
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

        [HttpPost("checkpointsaveclose/v2")]
        public async Task<ActionResult<ResponseSave>> saveclosePMCheckPointv2(List<JHStringSaveClose> JHSaveStringList)
        {
            ResponseSave response;
            string status = string.Empty;

            foreach (JHStringSaveClose JHSaveString in JHSaveStringList)
            {
                Prod_Execute_JHCheckList saveClose = new(Int32.Parse(JHSaveString.CheckListId), JHSaveString.CheckPointId, Int32.Parse(JHSaveString.CheckPointStatus), JHSaveString.CheckPointValue, JHSaveString.Remark);
                Console.WriteLine(saveClose.ToString());
                var ipqcList = await _context.Prod_Execute_JHCheckList.Where(a => a.CheckListId.Equals(saveClose.CheckListId) && a.CheckPointId.Equals(saveClose.CheckPointId)).ToListAsync();
                if (ipqcList.Count > 0)
                {
                    ipqcList.ForEach(a => a.CheckPointStatus = saveClose.CheckPointStatus);
                    ipqcList.ForEach(a => a.CheckPointValue = saveClose.CheckPointValue);
                    ipqcList.ForEach(a => a.Remark = saveClose.Remark);
                    Console.WriteLine(ipqcList.ToString());

                    await _context.SaveChangesAsync();
                    status = "Success";

                }
                else
                {
                    _context.Prod_Execute_JHCheckList.Add(saveClose);
                    await _context.SaveChangesAsync();
                    status = "Success";

                }

            }
            if (status == "Success")
            {
                    var schedule = await _context.Config_JHSchedule.Where(a => a.CheckListID.Equals(Int32.Parse(JHSaveStringList[0].CheckListId))).FirstOrDefaultAsync();
                    schedule.Status = 5;
                    schedule.DueDateTime = DateTime.Now.Date;
                    await _context.SaveChangesAsync();
                    status = "Success";
               
                    Prod_History_JHCheckList quality_History = new(Convert.ToDateTime(JHSaveStringList[0].CompletonDateTime), Convert.ToDateTime(JHSaveStringList[0].CompletonDateTime), JHSaveStringList[0].ProdShift, Int32.Parse(JHSaveStringList[0].CheckListId), JHSaveStringList[0].UserId, 5);
                    _context.Prod_History_JHCheckList.Add(quality_History);
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



    }

}
