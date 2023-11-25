using AtherMesRestApi.MESModels;
using System.Collections.Generic;

namespace AtherMesRestApi.ResponseModel
{
    public class ResponseCheckList
    {
        public string message { get; set; }
        public int status { get; set; }

        public List<IPQCPhaseChecklist> data { get; set; }

        public ResponseCheckList()
        {
            
        }

        public ResponseCheckList(string msg, int status, List<IPQCPhaseChecklist> data)
        {
            this.message = msg;
            this.status = status;
            this.data = data;
        }


    }
}
