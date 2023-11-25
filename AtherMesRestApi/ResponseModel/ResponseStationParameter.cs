using AtherMesRestApi.MESModels;
using System.Collections.Generic;

namespace AtherMesRestApi.ResponseModel
{
    public class ResponseStationParameter
    {
        public string message { get; set; }
        public int status { get; set; }

        public List<StationParameter> data { get; set; }

        public ResponseStationParameter()
        {
            
        }

        public ResponseStationParameter(string msg, int status, List<StationParameter> data)
        {
            this.message = msg;
            this.status = status;
            this.data = data;
        }


    }
}
