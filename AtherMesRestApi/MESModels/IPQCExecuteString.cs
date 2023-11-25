using System;

namespace AtherMesRestApi.MESModels
{
    public class IPQCExecuteString
    {
        public string RowId { get; set; }
        public string CheckListId { get; set; }
        public string CheckPointId { get; set; }
        public string CheckPointStatus { get; set; }
        public string CheckPointValue { get; set; }
        public string Remark { get; set; }
        public string Timestamp { get; set; }
        public string ProdDate { get; set; }
        public string ProdShift { get; set; }
        public string UserId { get; set; }
        public string Status { get; set; }
    }
}
