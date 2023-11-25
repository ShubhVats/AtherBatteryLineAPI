using System.Collections.Generic;
using AtherMesRestApi.MESModels;

namespace AtherMesRestApi.ResponseModel
{
    public class ResponseConfigUserCommon
    {
        public string message { get; set; }
        public int status { get; set; }

        public List<v_Config_User_Common> data { get; set; }

        public ResponseConfigUserCommon()
        {

        }

        public ResponseConfigUserCommon(string msg, int status, List<v_Config_User_Common> data)
        {
            this.message = msg;
            this.status = status;
            this.data = data;
        }


    }
}
