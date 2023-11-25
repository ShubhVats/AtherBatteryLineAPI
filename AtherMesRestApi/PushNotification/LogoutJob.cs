using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AtherMesRestApi.MESModels;
using Newtonsoft.Json;
using Quartz;

namespace AtherMesRestApi.PushNotification

{
    public class LogoutJob : IJob
    {

        private readonly MESDBContext _context;
        public LogoutJob(MESDBContext context)
        {
            _context = context;
        }
        public Task Execute(IJobExecutionContext context)
        {

            //ResponseMC
            try
            {
                Console.WriteLine("Logout Scan");

                string status = string.Empty;

                var shift = _context.ShiftInformation.First();

                if (shift.ShiftReset.Equals(1))
                {

                    //Get Token from station
                    var DHCStationlist = _context.StationMaster.ToList();


                    foreach (var devices in DHCStationlist)
                    {

                        //Send Notification
                        var baseUrl = "HTTP://192.168.201.242:8081/api/";

                        string endpoint = baseUrl + "notification/send";
                        string method = "POST";

                        NotificationModel notification = new NotificationModel();
                        notification.DeviceId = devices.Token;
                        notification.IsAndroiodDevice = true;
                        notification.Title = "LOGOUT";
                        notification.Body = "LOGOUT";

                        string json = JsonConvert.SerializeObject(notification);
                        WebClient wc = new WebClient();

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


                    }

                    _context.SaveChanges();
                    status = "Success";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            //Console.WriteLine(DateTime.Now);
            return Task.FromResult(true);
        }
    }
}
