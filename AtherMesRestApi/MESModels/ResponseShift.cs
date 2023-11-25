
using System.Collections.Generic;

namespace AtherMesRestApi.MESModels
{
    public class ResponseShift
    {
        public string message { get; set; }
        public int status { get; set; }

        public List<ShiftInformation> data { get; set; }

        public ResponseShift()
        {

        }

        public ResponseShift(string msg, int status, List<ShiftInformation> data)
        {
            this.message = msg;
            this.status = status;
            this.data = data;
        }

    }
}


