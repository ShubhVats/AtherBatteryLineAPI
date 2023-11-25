using System.Collections.Generic;

namespace AtherMesRestApi.MESModels
{
    public class ResponsePMChecklist
    {
        public int status { get; set; }
        public string response { get; set; }
        public List<PMPhaseList> PMPhaseList { get; set; }

        public ResponsePMChecklist(string response, int status, List<PMPhaseList> PMPhaseList)
        {
            this.status = status;
            this.response = response;
            this.PMPhaseList = PMPhaseList;
        }
    }
}
