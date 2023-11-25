using System;

namespace AtherMesRestApi.MESModels
{

    public class CheckPoint
    {
        public CheckPoint(string checkPointId, string checkPointName, string checkPointDescription, int checkListID, int category, string stationID, decimal estimatedDuration, decimal lowerLimit, decimal upperLimit, string uoM, int checkPointType, string criticality, DateTime createdOn, string createdBy, DateTime lastUpdatedOn, string lastUpdateBy)
        {
            CheckPointId = checkPointId;
            CheckPointName = checkPointName;
            CheckPointDescription = checkPointDescription;
            CheckListID = checkListID;
            Category = category;
            StationID = stationID;
            EstimatedDuration = estimatedDuration;
            LowerLimit = lowerLimit;
            UpperLimit = upperLimit;
            UoM = uoM;
            CheckPointType = checkPointType;
            Criticality = criticality;
            CreatedOn = createdOn;
            CreatedBy = createdBy;
            LastUpdatedOn = lastUpdatedOn;
            LastUpdateBy = lastUpdateBy;
        }

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
    }
}



