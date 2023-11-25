using AtherMesRestApi.MESModels;
using System.Collections.Generic;

namespace AtherMesRestApi.ResponseModel
{
    public class ResponseConfigParameter
    {
        public string message { get; set; }
        public int status { get; set; }

        public List<DHCParameters> data { get; set; }

        public ResponseConfigParameter()
        {
            
        }

        public ResponseConfigParameter(string msg, int status, List<DHCParameters> data)
        {
            this.message = msg;
            this.status = status;
            this.data = data;
        }


    }
}
