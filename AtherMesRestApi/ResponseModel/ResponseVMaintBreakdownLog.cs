
using System.Collections.Generic;
using AtherMesRestApi.MESModels;

namespace AtherMesRestApi.ResponseModel
{
    public class ResponseVMaintBreakdownLog
    {
        public string message { get; set; }
        public int status { get; set; }

        public List<v_Maint_Breakdown_Log> data { get; set; }

        public ResponseVMaintBreakdownLog()
        {

        }

        public ResponseVMaintBreakdownLog(string msg, int status, List<v_Maint_Breakdown_Log> data)
        {
            this.message = msg;
            this.status = status;
            this.data = data;
        }


    }
}
