namespace AtherMesRestApi.MESModels
{
    public class Maint_Breakdown_Log_Input
    {
        public string BreakdownID { get; set; }
        public string AlarmId { get; set; }
        public string ProDate { get; set; }
        public string ProdShift { get; set; }
        public string StationId { get; set; }
        public string AssetId { get; set; }
        public string BDStartTime { get; set; }
        public string BDEndTime { get; set; }
        public string BDDuration { get; set; }
        public string TotalBDTime { get; set; }
        public string TotalBDCount { get; set; }
        public string LossCode { get; set; }
        public string SubLossCode { get; set; }
        public string BDReason { get; set; }
        public string BDRemark { get; set; }
        public string Status { get; set; }

    }
}
