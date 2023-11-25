using AtherMesRestApi.MESModels;
using System.Collections.Generic;

namespace AtherMesRestApi.ResponseModel
{
    public class ResponsePreviousStation
    {
        public string message { get; set; }
        public int status { get; set; }

        public List<PreviousStation> data { get; set; }

        public ResponsePreviousStation()
        {
            
        }

        public ResponsePreviousStation(string msg, int status, List<PreviousStation> data)
        {
            this.message = msg;
            this.status = status;
            this.data = data;
        }


    }
}
