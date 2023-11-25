using System;

namespace AtherMesRestApi.MESModels
{
    public class RejectionWIP
    {
        public int RowId { get; set; }
        public string ParameterId { get; set; }
        public string ParameterVal { get; set; }
        public string BIN_Number { get; set; }
        public int StationId { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string OperatorRemark { get; set; }
        public Int64 BUGId { get; set; }
        public string QIRemarks { get; set; }
        public string RSARemark { get; set; }
        public int Status { get; set; }
    }
}
