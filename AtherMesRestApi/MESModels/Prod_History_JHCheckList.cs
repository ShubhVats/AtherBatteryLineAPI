using System;
using System.ComponentModel.DataAnnotations;

namespace AtherMesRestApi.MESModels
{
    public class Prod_History_JHCheckList
    {
        public Prod_History_JHCheckList(DateTime timestamp, DateTime prodDate, string productionShift, int checkListId, string userId, int status)
        {
            Timestamp = DateTime.Now;
            ProdDate = prodDate;
            ProductionShift = productionShift;
            CheckListId = checkListId;
            UserId = userId;
            Status = status;
        }

        [Key]
        public DateTime Timestamp { get; set; }
        public DateTime ProdDate { get; set; }
        public string ProductionShift { get; set; }
        public int CheckListId { get; set; }
        public string UserId { get; set; }
        public int Status { get; set; }
    }
}
