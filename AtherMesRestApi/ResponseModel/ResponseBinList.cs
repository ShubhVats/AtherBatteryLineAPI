using AtherMesRestApi.MESModels;
using System.Collections.Generic;

namespace AtherMesRestApi.ResponseModel
{
    public class ResponseBinList
    {
        public string message { get; set; }
        public int status { get; set; }

        public List<BinList> data { get; set; }

        public ResponseBinList()
        {
            
        }

        public ResponseBinList(string msg, int status, List<BinList> data)
        {
            this.message = msg;
            this.status = status;
            this.data = data;
        }


    }
}
