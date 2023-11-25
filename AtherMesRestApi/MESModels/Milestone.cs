using System.Collections.Generic;

namespace AtherMesRestApi.MESModels
{
    public class Milestones
    {


        public List<Mile_Stone> Milestone { get; set; }


        public class Mile_Stone
        {
            public string Prod_Order { get; set; }
            public string BIN { get; set; }
            public string LineID { get; set; }
            public string MilestoneID { get; set; }
            public int Status { get; set; }

        }

    }
}