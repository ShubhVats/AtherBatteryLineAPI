using System.Collections.Generic;

namespace AtherMesRestApi.ResponseModel
{
    public class ResponseMC
    {
        public MilestoneConfirm MT_Milestone_confirm_Resp { get; set; }


        public class MilestoneConfirm
        {
            public List<Mile> response { get; set; }

        }
        public class Mile
        {
            public string production_Order_No { get; set; }
            public string MilestoneID { get; set; }
            public string messageType { get; set; }
            public string message { get; set; }

        }

    }
}