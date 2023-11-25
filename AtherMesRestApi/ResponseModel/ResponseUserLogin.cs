using AtherMesRestApi.MESModels;
using System.Collections.Generic;

namespace AtherMesRestApi.ResponseModel
{
    public class ResponseUserLogin
    {
        public string message { get; set; }
        public int status { get; set; }

        public List<UserLogin> data { get; set; }

        public ResponseUserLogin()
        {
            
        }

        public ResponseUserLogin(string msg, int status, List<UserLogin> data)
        {
            this.message = msg;
            this.status = status;
            this.data = data;
        }


    }
}
