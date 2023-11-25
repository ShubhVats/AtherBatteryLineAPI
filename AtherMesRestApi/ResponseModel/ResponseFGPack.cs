using AtherMesRestApi.MESModels;

namespace AtherMesRestApi.ResponseModel
{
    public class ResponseFGPack
    {

        public string message { get; set; }
        public int status { get; set; }

        public FGResponse data { get; set; }

        public ResponseFGPack()
        {

        }

        public ResponseFGPack(string msg, int status, FGResponse data)
        {
            this.message = msg;
            this.status = status;
            this.data = data;
        }


    }
}
