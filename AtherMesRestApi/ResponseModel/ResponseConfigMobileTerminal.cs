using AtherMesRestApi.MESModels;
using System.Collections.Generic;

namespace AtherMesRestApi.ResponseModel
{
    public class ResponseConfigMobileTerminal
    {
        public string message { get; set; }
        public int status { get; set; }

        public List<MobileTerminalConfig> data { get; set; }

        public ResponseConfigMobileTerminal()
        {
            
        }

        public ResponseConfigMobileTerminal(string msg, int status, List<MobileTerminalConfig> data)
        {
            this.message = msg;
            this.status = status;
            this.data = data;
        }


    }
}
