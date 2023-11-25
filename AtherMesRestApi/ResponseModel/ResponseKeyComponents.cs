using AtherMesRestApi.MESModels;
using System.Collections.Generic;

namespace AtherMesRestApi.ResponseModel
{
    public class ResponseKeyComponents
    {

        public string message { get; set; }
        public int status { get; set; }

        public List<SAP_KEY_COMPONENT_BOOKING>  data { get; set; }

        public ResponseKeyComponents()
        {

        }

        public ResponseKeyComponents(string msg, int status, List<SAP_KEY_COMPONENT_BOOKING>  data)
        {
            this.message = msg;
            this.status = status;
            this.data = data;
        }
    }
}
