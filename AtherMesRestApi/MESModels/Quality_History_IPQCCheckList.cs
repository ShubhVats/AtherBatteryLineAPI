using System;
using System.ComponentModel.DataAnnotations;

namespace AtherMesRestApi.MESModels
{
    public class Quality_History_IPQCCheckList
    {
        [Key]
        public int RowId { get; set; }
        public DateTime Timestamp { get; set; }
        public DateTime ProdDate { get; set; }
        public string ProdShift { get; set; }
        public int CheckListId { get; set; }
        public string UserId { get; set; }
        public int Status { get; set; }
        public int Instance { get; set; }

        public Quality_History_IPQCCheckList(DateTime timestamp, DateTime prodDate, string prodShift, int checkListId, string userId, int status, int instance)
        {
            Timestamp = timestamp;
            ProdDate = prodDate;
            ProdShift = prodShift;
            CheckListId = checkListId;
            UserId = userId;
            Status = status;
            Instance = instance;
        }
    }
}
