using AtherMesRestApi.MESModels;

namespace AtherMesRestApi.ResponseModel
{
    public class ResponseIPQCVal
    {
        public string message { get; set; }
        public int status { get; set; }

        public IPQCVal data { get; set; }

        public ResponseIPQCVal()
        {

        }

        public ResponseIPQCVal(string msg, int status, IPQCVal data)
        {
            this.message = msg;
            this.status = status;
            this.data = data;
        }

    }
}
