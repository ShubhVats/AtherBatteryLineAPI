using AtherMesRestApi.MESModels;
using System.Collections.Generic;

namespace AtherMesRestApi.ResponseModel
{
    public class ResponseCallLog
    {
        public string message { get; set; }
        public int status { get; set; }

        public List<CallLogModel> data { get; set; }

        public ResponseCallLog()
        {
            
        }

        public ResponseCallLog(string msg, int status, List<CallLogModel> data)
        {
            this.message = msg;
            this.status = status;
            this.data = data;
        }


    }
}
