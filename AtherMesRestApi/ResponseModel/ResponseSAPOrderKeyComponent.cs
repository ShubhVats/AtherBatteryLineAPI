using AtherMesRestApi.MESModels;
using System.Collections.Generic;

namespace AtherMesRestApi.ResponseModel
{
    public class ResponseSAPOrderKeyComponent :ResponseCommon
    {
        public List<SapProductionKeyComponents> data { get; set; }

        public ResponseSAPOrderKeyComponent(string message, int status, List<SapProductionKeyComponents> data)
        {
            this.message = message;
            this.status = status;
            this.data = data;
        }
    }

}
