using System.Collections.Generic;

namespace AtherMesRestApi.MESModels
{
    public class ResponseAllParameterValue
    {
        public string message { get; set; }
        public int status { get; set; }

        public List<string> data { get; set; }

        public ResponseAllParameterValue()
        {

        }

        public ResponseAllParameterValue(string msg, int status, List<string> data)
        {
            this.message = msg;
            this.status = status;
            this.data = data;
        }


    }
}
