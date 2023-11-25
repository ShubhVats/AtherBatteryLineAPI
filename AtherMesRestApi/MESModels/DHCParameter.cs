using System;
using System.Collections.Generic;

namespace AtherMesRestApi.MESModels
{
    public class DHCParameters
    {
        public string ParameterId { get; set; }
        public string ParameterDescription { get; set; }
        public int Category { get; set; }
        public int EstimatedDuration { get; set; }
        public decimal LowerLimit { get; set; }
        public decimal UpperLimit { get; set; }
        public string UOM { get; set; }
        public int CheckPointType { get; set; }
        public int Criticality { get; set; }
        public string SKU { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public string LastUpdatedBy { get; set; }
        public int LineId { get; set; }
        public string StationId { get; set; }
    }
}
