using System;

namespace AtherMesRestApi.MESModels
{
    public class IPQCExecute
    {
        public IPQCExecute(int checkListId, string checkPointId, int checkPointStatus, decimal checkPointValue, string remark, DateTime timestamp, DateTime prodDate, string prodShift, string userId, int status)
        {
            CheckListId = checkListId;
            CheckPointId = checkPointId;
            CheckPointStatus = checkPointStatus;
            CheckPointValue = checkPointValue;
            Remark = remark;
            Timestamp = timestamp;
            ProdDate = prodDate;
            ProdShift = prodShift;
            UserId = userId;
            Status = status;
        }

        public int RowId { get; set; }
        public int CheckListId { get; set; }
        public string CheckPointId { get; set; }
        public int CheckPointStatus { get; set; }
        public decimal CheckPointValue { get; set; }
        public string Remark { get; set; }
        public DateTime Timestamp { get; set; }
        public DateTime ProdDate { get; set; }
        public string ProdShift { get; set; }
        public string UserId { get; set; }
        public int Status { get; set; }
    }
}
