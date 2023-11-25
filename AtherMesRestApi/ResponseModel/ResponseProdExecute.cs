using AtherMesRestApi.MESModels;

namespace AtherMesRestApi.ResponseModel
{
    public class ResponseProdExecute
    {
        public string message { get; set; }
        public int status { get; set; }

        public Prod_ProductionExecution data { get; set; }

        public ResponseProdExecute()
        {

        }

        public ResponseProdExecute(string msg, int status, Prod_ProductionExecution data)
        {
            this.message = msg;
            this.status = status;
            this.data = data;
        }


    }
}
