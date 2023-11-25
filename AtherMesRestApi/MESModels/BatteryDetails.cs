namespace AtherMesRestApi.MESModels
{

    public class BatteryDetails
    {
        public string line { get; set; }
        public string Timestamp { get; set; }
        public string BIN_Number { get; set; }
        public string StationId { get; set; }
        public string StationName { get; set; }
        public string ParameterId { get; set; }
        public string ParameterVal { get; set; }
        public string Quality { get; set; }
        public string Status { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string OperatorRemark { get; set; }
        public string BUGId { get; set; }
        public string QIRemarks { get; set; }
        public string RSARemark { get; set; }
        public string ReEntryStation { get; set; }
        public string PartChangeFlag { get; set; }
        public string SKUChangeFlag { get; set; }
        public string ReworkRemark { get; set; }
        public string SaveFlag { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Timer { get; set; }
        public string PlanID { get; set; }
        public string ReworkStationName { get; set; }
    }
}

