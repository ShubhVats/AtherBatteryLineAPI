using System.Collections.Generic;
using AtherMesRestApi.MESModels;

namespace AtherMesRestApi.ResponseModel
{
    public class ResponseConfigUser
    {
        public string message { get; set; }
        public int status { get; set; }

        public List<Config_User> data { get; set; }

        public ResponseConfigUser()
        {

        }

        public ResponseConfigUser(string msg, int status, List<Config_User> data)
        {
            this.message = msg;
            this.status = status;
            this.data = data;
        }


    }
}
