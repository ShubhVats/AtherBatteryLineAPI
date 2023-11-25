
using System.Collections.Generic;
using AtherMesRestApi.MESModels;

namespace AtherMesRestApi.ResponseModel
{
    public class ResponseAssignedUsers
    {
        public string message { get; set; }
        public int status { get; set; }

        public List<Config_LineUserAssigment> data { get; set; }

        public ResponseAssignedUsers()
        {

        }

        public ResponseAssignedUsers(string msg, int status, List<Config_LineUserAssigment> data)
        {
            this.message = msg;
            this.status = status;
            this.data = data;
        }


    }
}
