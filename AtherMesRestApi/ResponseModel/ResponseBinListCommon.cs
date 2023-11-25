using System.Collections.Generic;
using AtherMesRestApi.MESModels;

namespace AtherMesRestApi.ResponseModel
{
    public class ResponseBinListCommon
    {
        public string message { get; set; }
        public int status { get; set; }

        public List<BinListCommon> data { get; set; }

        public ResponseBinListCommon()
        {

        }

        public ResponseBinListCommon(string msg, int status, List<BinListCommon> data)
        {
            this.message = msg;
            this.status = status;
            this.data = data;
        }


    }
}
