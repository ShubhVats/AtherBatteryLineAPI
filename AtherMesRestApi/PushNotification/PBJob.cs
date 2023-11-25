using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtherMesRestApi.MESModels;
using AtherMesRestApi.ResponseModel;
using Newtonsoft.Json;
using Quartz;

namespace AtherMesRestApi.PushNotification

{
    public class PBJob : IJob
    {

        private readonly MESDBContext _context;
        public PBJob(MESDBContext context)
        {
            _context = context;
        }
        public Task Execute(IJobExecutionContext context)
        {

            //ResponseMC
            try
            {
                Console.WriteLine("PB Update");

                string status = string.Empty;

                var checkList = _context.SAP_Mileston_Response.Where(a => a.MessageType.Equals(null))
                     .ToList();

                List<ResponseMC> Userlist = new List<ResponseMC>();

                for (int i = 0; i < checkList.Count; i++)
                {
                    ResponseMC _response = JsonConvert.DeserializeObject<ResponseMC>(checkList[i].ResponseBody);

                    string messages = "";

                    for (int j = 0; j < _response.MT_Milestone_confirm_Resp.response.Count(); j++)
                    {
                        if (_response.MT_Milestone_confirm_Resp.response[j].production_Order_No.Equals("0000000000NA"))
                        {
                            messages = messages + _response.MT_Milestone_confirm_Resp.response[j].messageType + " , ";
                        }
                    }

                    checkList.ForEach(a => a.MessageType = messages);

                }
                _context.SaveChanges();
                status = "Success";
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
