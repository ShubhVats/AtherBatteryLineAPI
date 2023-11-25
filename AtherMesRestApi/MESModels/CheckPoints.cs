using System;

namespace AtherMesRestApi.MESModels
{
    public class CheckPoints
    {

        public string CheckPointId { get; set; }
        public string CheckPointName { get; set; }
        public string CheckPointDescription { get; set; }
        public int CheckListID { get; set; }
        public int Category { get; set; }
        public string StationID { get; set; }
        public decimal EstimatedDuration { get; set; }
        public decimal LowerLimit { get; set; }
        public decimal UpperLimit { get; set; }
        public string UoM { get; set; }
        public int CheckPointType { get; set; }
        public string Criticality { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public string LastUpdateBy { get; set; }


       
        public string CheckPointStatus { get; set; }
        public string CheckPointValue { get; set; }
     
        public string Remark { get; set; }


        public string Instance { get; set; }



    }
}
