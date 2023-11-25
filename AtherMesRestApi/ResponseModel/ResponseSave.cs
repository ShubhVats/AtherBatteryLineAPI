namespace AtherMesRestApi.ResponseModel
{
    public class ResponseSave
    {
        public string message { get; set; }
        public int status { get; set; }
        public ResponseSave(string msg, int status )
        {
            this.message = msg;
            this.status = status;
        }
        
    }
}
