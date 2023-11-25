using AtherMesRestApi.MESModels;
using System.Collections.Generic;

namespace AtherMesRestApi.ResponseModel
{
    public class ResponseCheckPoint
    {
        public string message { get; set; }
        public int status { get; set; }

        public List<CheckPoint> data { get; set; }

        public ResponseCheckPoint()
        {
            
        }

        public ResponseCheckPoint(string msg, int status, List<CheckPoint> data)
        {
            this.message = msg;
            this.status = status;
            this.data = data;
        }


    }
}
