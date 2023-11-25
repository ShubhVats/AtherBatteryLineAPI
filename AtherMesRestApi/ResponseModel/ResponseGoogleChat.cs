using System.Collections.Generic;
using AtherMesRestApi.MESModels;

namespace AtherMesRestApi.ResponseModel
{
    public class ResponseGoogleChat
    {
        public string message { get; set; }
        public int status { get; set; }

        public List<GoogleChat> data { get; set; }

        public ResponseGoogleChat()
        {

        }

        public ResponseGoogleChat(string msg, int status, List<GoogleChat> data)
        {
            this.message = msg;
            this.status = status;
            this.data = data;
        }

    }
}
