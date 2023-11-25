using System.Collections.Generic;

namespace AtherMesRestApi.MESModels
{
    public class ResponsePMCheckPoint
    {
        public string message { get; set; }
        public int status { get; set; }

        public List<PMCheckPoint> data { get; set; }

        public ResponsePMCheckPoint()
        {

        }

        public ResponsePMCheckPoint(string msg, int status, List<PMCheckPoint> data)
        {
            this.message = msg;
            this.status = status;
            this.data = data;
        }

    }
}
