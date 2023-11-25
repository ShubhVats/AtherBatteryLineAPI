namespace AtherMesRestApi.MESModels
{
    public class ResponseParameterValue
    {
        public string message { get; set; }
        public int status { get; set; }

        public string data { get; set; }

        public ResponseParameterValue()
        {

        }

        public ResponseParameterValue(string msg, int status, string data)
        {
            this.message = msg;
            this.status = status;
            this.data = data;
        }


    }
}
