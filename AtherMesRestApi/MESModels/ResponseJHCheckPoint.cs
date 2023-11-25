using System.Collections.Generic;

namespace AtherMesRestApi.MESModels
{
    public class ResponseJHCheckPoint
    {
        public string message { get; set; }
        public int status { get; set; }

        public List<Config_JHCheckPoint> data { get; set; }

        public ResponseJHCheckPoint()
        {

        }

        public ResponseJHCheckPoint(string msg, int status, List<Config_JHCheckPoint> data)
        {
            this.message = msg;
            this.status = status;
            this.data = data;
        }

    }
}

