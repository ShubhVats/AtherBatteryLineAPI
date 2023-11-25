using System;
using System.ComponentModel.DataAnnotations;

namespace AtherMesRestApi.MESModels
{
    public class v_Maint_Breakdown_Log
    {
        [Key]
        public int BreakdownID { get; set; }
        public string AlarmId { get; set; }
        public string UserID { get; set; }
        public DateTime ProDate { get; set; }
        public string ProdShift { get; set; }
        public string StationId { get; set; }
        public string AssetId { get; set; }
        public DateTime BDStartTime { get; set; }
        public DateTime BDEndTime { get; set; }
        public int TotalBDTime { get; set; }
        public int TotalBDCount { get; set; }
        public string LossCode { get; set; }
        public string SubLossCode { get; set; }
        public string BDReason { get; set; }
        public string BDRemark { get; set; }
        public int Status { get; set; }

    }
}
