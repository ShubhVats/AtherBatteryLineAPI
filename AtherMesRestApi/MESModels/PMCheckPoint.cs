using System;

namespace AtherMesRestApi.MESModels
{
    public class PMCheckPoint
    {

        public string CheckPointId { get; set; }
        public string CheckPointName { get; set; }
        public int CheckListID { get; set; }
        public int Category { get; set; }
        public decimal EstimatedDuration { get; set; }
        public decimal LowerLimit { get; set; }
        public decimal UpperLimit { get; set; }
        public string UOM { get; set; }
        public int CheckPointType { get; set; }
        public int Criticality { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public string LastUpdatedBy { get; set; }

    }
}
