using System.Collections.Generic;

namespace AtherMesRestApi.MESModels
{
    public class ResponseJHChecklist
    {
        public string message { get; set; }
        public int status { get; set; }

        public List<JHCheckList> data { get; set; }

        public ResponseJHChecklist()
        {

        }

        public ResponseJHChecklist(string msg, int status, List<JHCheckList> data)
        {
            this.message = msg;
            this.status = status;
            this.data = data;
        }

    }
}
