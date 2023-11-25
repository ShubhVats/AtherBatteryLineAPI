using System;

namespace AtherMesRestApi.MESModels
{
    public class StationMaster
    {
        public int LineId { get; set; }
        public int StationId { get; set; }
        public string StationName { get; set; }
        public int StationTaktTime { get; set; }
        public string StationDescription { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public string LastUpdatedBy { get; set; }
        public int PlanCycleTime { get; set; }
        public int PlanLoadTime{ get; set; }
        public int PlanUnloadTime{ get; set; }
        public string Token{ get; set; }
    }
}
