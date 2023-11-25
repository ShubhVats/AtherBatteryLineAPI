using System;
using System.ComponentModel.DataAnnotations;

namespace AtherMesRestApi.MESModels
{
    public class Maint_History_PMCheckList
    {
        public Maint_History_PMCheckList(DateTime timestamp, DateTime prodDate, string productionShift, int checkListId, string userId, int status, int instance)
        {
            Timestamp = timestamp;
            ProdDate = prodDate;
            ProductionShift = productionShift;
            CheckListId = checkListId;
            UserId = userId;
            Status = status;
            Instance = instance;
        }

        [Key]
        public DateTime Timestamp { get; set; }
        public DateTime ProdDate { get; set; }
        public string ProductionShift { get; set; }
        public int CheckListId { get; set; }
        public string UserId { get; set; }
        public int Status { get; set; }
        public int Instance { get; set; }
    }
}
