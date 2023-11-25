namespace AtherMesRestApi.MESModels
{
    public class GetBatteryDetailsCommon
    {
        public int LineId { get; set; }
        public string BIN_Number { get; set; }
        public int StationId { get; set; }
        public string ParameterId { get; set; }
        public string ParameterVal { get; set; }
        public int Status { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string OperatorRemark { get; set; }
        public string BUGId { get; set; }
        public string QIRemarks { get; set; }
        public string RSARemark { get; set; }
        //public int ReEntryStation { get; set; }
        public int PartChangeFlag { get; set; }
        public int SKUChangeFlag { get; set; }
        public string ReworkRemark { get; set; }
        public int SaveFlag { get; set; }
        //public DateTime StartTime { get; set; }
        //public DateTime EndTime { get; set; }
        //public string StationName { get; set; }
    }
}
