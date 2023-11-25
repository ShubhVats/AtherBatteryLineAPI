using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AtherMesRestApi.MESModels;
using AtherMesRestApi.PushNotification;
using AtherMesRestApi.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace AtherMesRestApi.Controllers
{
    [Route("api/CallLog")]
    [ApiController]
    public class CallLogController : Controller
    {
        private readonly MESDBContext _context;

        public CallLogController(MESDBContext context)
        {
            _context = context;
        }

        //GET: api/SapOrders/5

        [HttpGet("{receiver}/{line}")]
        public async Task<ActionResult<ResponseCallLog>> getCallLog(string receiver, int line)
        {
            ResponseCallLog response;
            var CallLogList = await _context.CallLog.Where(a => a.RECEIVER.Equals(receiver) && a.CallStatus != 3)
                 .ToListAsync();

            if (CallLogList == null)
            {
                response = new ResponseCallLog("data not found", 300, null);
                //return NotFound();
            }
            else
            {
                if (CallLogList.Count > 0)
                {
                    response = new ResponseCallLog("data found", 200, CallLogList);

                }
                else
                {
                    response = new ResponseCallLog("data not found", 300, null);

                }

            }

            return response;
        }

        [HttpPost("post")]
        public async Task<ActionResult<ResponseSave>> postCallLog(CallLog callLog)
        {
            var shiftList = await _context.ShiftInformation.FirstOrDefaultAsync();


            string status = string.Empty;
            CallLogModel callLogModel = new(shiftList.ProductionDate, shiftList.ShiftName, Int32.Parse(callLog.LineID), callLog.StationID, callLog.SENDER, callLog.RECEIVER, Convert.ToDateTime(callLog.StartTime), Convert.ToDateTime(callLog.ACKTime), Convert.ToDateTime(callLog.EndTime), Int32.Parse(callLog.CallStatus));

            //Get Token from station
            var DHCStationlist = await _context.StationMaster
                .Where(a => a.LineId.Equals(callLogModel.LineID) && a.StationName.Equals(callLogModel.RECEIVER))
                     .ToListAsync();
            var token = DHCStationlist[0].Token;


            var baseUrl = "HTTP://192.168.201.242:8081/api/";

            string endpoint = baseUrl + "notification/send";
            string method = "POST";

            NotificationModel notification = new NotificationModel();
            notification.DeviceId = token;
            notification.IsAndroiodDevice = true;
            notification.Title = "New Notification!";
            if (callLog.BinNumber == null || callLog.BinNumber.Equals(" "))
            {
                notification.Body = "You have a notification from " + callLogModel.SENDER + " at " + callLogModel.StationID;

            }
            else
            {
                notification.Body = "You have a notification from " + callLogModel.SENDER + " at " + callLogModel.StationID + " with BIN " + callLog.BinNumber;
            }
            //binnumber

            string json = JsonConvert.SerializeObject(notification);
            WebClient wc = new WebClient();
            //string idpwb64 = "NUNfQ09NUDpBUEkjMTIzNA==";

            wc.Headers["Content-Type"] = "application/json";
            try
            {
                var responseAPI = wc.UploadString(endpoint, method, json);

                Console.WriteLine("response:" + responseAPI);

                //                Responses _response = JsonConvert.DeserializeObject<Responses>(response);

                //return JsonConvert.DeserializeObject<SPResponse_DOWN>(response);
                //              return _response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now + " Api Operations exception: " + ", " + ex.ToString());


            }

            ResponseSave response;
            try
            {
                _context.CallLog.Add(callLogModel); ;
                await _context.SaveChangesAsync();
                status = "Success";



            }
            catch (DbUpdateException e)
            {
                status = "Error" + e;
            }
            if (status == "Success")
            {
                response = new ResponseSave("Notification sent successfully!", 200);
            }
            else
            {
                response = new ResponseSave("Notification not sent.", 300);
            }

            return response;
        }

        [HttpPost("put")]
        public async Task<ActionResult<ResponseSave>> putCallLog(UpdateCall updatecallLog)
        {
            var CallLogList = await _context.CallLog.Where(a => a.RowId.Equals(Int32.Parse(updatecallLog.rowId)))
                 .ToListAsync();
            CallLogList.ForEach(a => a.ACKTime = Convert.ToDateTime(updatecallLog.ackTime));
            CallLogList.ForEach(a => a.EndTime = Convert.ToDateTime(updatecallLog.endTime));
            CallLogList.ForEach(a => a.CallStatus = Int32.Parse(updatecallLog.callStatus));
            string status = string.Empty;

            ResponseSave response;
            try
            {
                await _context.SaveChangesAsync();
                status = "Success";

            }
            catch (DbUpdateException e)
            {
                status = "Error" + e;
            }

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
