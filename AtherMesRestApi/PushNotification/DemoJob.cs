using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AtherMesRestApi.MESModels;
using Newtonsoft.Json;
using Quartz;

namespace AtherMesRestApi.PushNotification

{
    public class DemoJob : IJob
    {

        private readonly MESDBContext _context;
        public DemoJob(MESDBContext context)
        {
            _context = context;
        }
        public Task Execute(IJobExecutionContext context)
        {

            try
            {

                string status = string.Empty;

                var checkList = _context.CheckList.Where(a => a.Status == 2 || a.Status == 3)
                     .ToList();

                List<Config_User> Userlist = new List<Config_User>();

                for (int i = 0; i < checkList.Count; i++)
                {
                    Userlist = _context.Config_User.Where(a => a.UserId.Equals(checkList[i].AssignedUser))
                          .ToList();
                    if (checkList.Count > 0 && Userlist.Count > 0)
                    {
                        for (int j = 0; j < Userlist.Count; j++)
                        {
                            var token = Userlist[j].Token;
                            var baseUrl = "HTTP://192.168.200.233:8081/api/";

                            string endpoint = baseUrl + "notification/send";
                            string method = "POST";

                            NotificationModel notification = new NotificationModel();
                            notification.DeviceId = token;
                            notification.IsAndroiodDevice = true;
                            notification.Title = "New Notification!";
                            notification.Body = "You have a pending IPQC checklist " + checkList[i].CheckListName + "!";


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
                            //Write your custom code here
                            Console.WriteLine(DateTime.Now);

                        }
                    }
                    else
                    {
                        Console.WriteLine("No JH rightnow.:" + DateTime.Now);
                    }

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine(DateTime.Now);
            return Task.FromResult(true);
        }
    }
}
