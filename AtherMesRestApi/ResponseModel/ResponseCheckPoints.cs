using AtherMesRestApi.MESModels;
using System.Collections.Generic;

namespace AtherMesRestApi.ResponseModel
{
    public class ResponseCheckPoints
    {

        public string message { get; set; }
        public int status { get; set; }

        public List<CheckPoints> data { get; set; }

        public ResponseCheckPoints()
        {

        }

        public ResponseCheckPoints(string msg, int status, List<CheckPoints> data)
        {
            this.message = msg;
            this.status = status;
            this.data = data;
        }

    }
}
