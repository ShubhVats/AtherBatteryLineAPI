using System.Collections.Generic;
using AtherMesRestApi.MESModels;

namespace AtherMesRestApi.ResponseModel
{
    public class ResponseBatteryWIP
    {
        public string message { get; set; }
        public int status { get; set; }

        public List<BatteryWIP> data { get; set; }

        public ResponseBatteryWIP()
        {

        }

        public ResponseBatteryWIP(string msg, int status, List<BatteryWIP> data)
        {
            this.message = msg;
            this.status = status;
            this.data = data;
        }


    }
}
