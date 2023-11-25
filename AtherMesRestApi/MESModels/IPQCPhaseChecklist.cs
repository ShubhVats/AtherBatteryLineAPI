using System.Collections.Generic;

namespace AtherMesRestApi.MESModels
{
    public class IPQCPhaseChecklist
    {
        public IPQCPhaseChecklist(string phase, List<CheckList> data)
        {
            this.phase = phase;
            this.data = data;
        }

        public string phase { get; set; }
        public List<CheckList> data { get; set; }

    }
}
