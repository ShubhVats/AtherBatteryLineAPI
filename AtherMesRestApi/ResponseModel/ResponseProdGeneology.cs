using AtherMesRestApi.MESModels;
using System.Collections.Generic;

namespace AtherMesRestApi.ResponseModel
{
    public class ResponseProdGeneology
    {
        public string message { get; set; }
        public int status { get; set; }

        public List<GeneologyProd> data { get; set; }

        public ResponseProdGeneology()
        {
            
        }

        public ResponseProdGeneology(string msg, int status, List<GeneologyProd> data)
        {
            this.message = msg;
            this.status = status;
            this.data = data;
        }


    }
}
