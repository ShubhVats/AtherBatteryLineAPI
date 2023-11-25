using System.Collections.Generic;

namespace AtherMesRestApi.MESModels
{
    public class PMPhaseList
    {
        public PMPhaseList(string phase, List<PMCheckList> data)
        {
            this.phase = phase;
            this.data = data;
        }

        public string phase { get; set; }
        public List<PMCheckList> data { get; set; }

    }
}

