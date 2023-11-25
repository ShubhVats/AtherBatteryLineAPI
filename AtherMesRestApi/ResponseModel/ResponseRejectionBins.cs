using System.Collections.Generic;
using AtherMesRestApi.MESModels;

namespace AtherMesRestApi.ResponseModel
{
    public class ResponseRejectionBins
    {
        public string message { get; set; }
        public int status { get; set; }

        public List<GetBatteryDetails> data { get; set; }

        public ResponseRejectionBins()
        {

        }

        public ResponseRejectionBins(string msg, int status, List<GetBatteryDetails> data)
        {
            this.message = msg;
            this.status = status;
            this.data = data;
        }
    }
}
