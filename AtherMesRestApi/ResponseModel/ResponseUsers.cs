using System.Collections.Generic;

namespace AtherMesRestApi.ResponseModel
{
    public class ResponseUsers
    {
        public string message { get; set; }
        public int status { get; set; }

        public List<string> data { get; set; }

        public ResponseUsers()
        {

        }

        public ResponseUsers(string msg, int status, List<string> data)
        {
            this.message = msg;
            this.status = status;
            this.data = data;
        }


    }
}

