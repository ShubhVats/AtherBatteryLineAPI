using System.Collections.Generic;
using AtherMesRestApi.MESModels;

namespace AtherMesRestApi.ResponseModel
{
    public class ResponseRejectionBinsCommon
    {
        public string message { get; set; }
        public int status { get; set; }

        public List<GetBatteryDetailsCommon> data { get; set; }

        public ResponseRejectionBinsCommon()
        {

        }

        public ResponseRejectionBinsCommon(string msg, int status, List<GetBatteryDetailsCommon> data)
        {
            this.message = msg;
            this.status = status;
            this.data = data;
        }
    }
}
