using AtherMesRestApi.MESModels;
using System.Collections.Generic;

namespace AtherMesRestApi.ResponseModel
{
    public class ResponseConfigBugList
    {
        public string message { get; set; }
        public int status { get; set; }

        public List<BugListConfig> data { get; set; }

        public ResponseConfigBugList()
        {
            
        }

        public ResponseConfigBugList(string msg, int status, List<BugListConfig> data)
        {
            this.message = msg;
            this.status = status;
            this.data = data;
        }


    }
}
