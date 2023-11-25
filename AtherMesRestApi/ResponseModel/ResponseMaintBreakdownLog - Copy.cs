
using System.Collections.Generic;
using AtherMesRestApi.MESModels;

namespace AtherMesRestApi.ResponseModel
{
    public class ResponseMaintBreakdownLog
    {
        public string message { get; set; }
        public int status { get; set; }

        public List<Maint_Breakdown_Log> data { get; set; }

        public ResponseMaintBreakdownLog()
        {

        }

        public ResponseMaintBreakdownLog(string msg, int status, List<Maint_Breakdown_Log> data)
        {
            this.message = msg;
            this.status = status;
            this.data = data;
        }


    }
}
