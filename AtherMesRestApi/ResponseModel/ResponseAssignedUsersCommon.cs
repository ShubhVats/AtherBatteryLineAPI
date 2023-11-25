
using System.Collections.Generic;
using AtherMesRestApi.MESModels;

namespace AtherMesRestApi.ResponseModel
{
    public class ResponseAssignedUsersCommon
    {
        public string message { get; set; }
        public int status { get; set; }

        public List<Config_UserAssigment> data { get; set; }

        public ResponseAssignedUsersCommon()
        {

        }

        public ResponseAssignedUsersCommon(string msg, int status, List<Config_UserAssigment> data)
        {
            this.message = msg;
            this.status = status;
            this.data = data;
        }


    }
}
