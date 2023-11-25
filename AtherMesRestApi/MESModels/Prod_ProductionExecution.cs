using System;
using System.ComponentModel.DataAnnotations;

namespace AtherMesRestApi.MESModels
{

    public class Prod_ProductionExecution
    {
        public Prod_ProductionExecution()
        {
            PlanID = 0;
            ProdDate = DateTime.Now;
            Shift = "";
            Lineid = 0;
            ShopId = 0;
            SKUId = "";
            Plan = 0;
            OrderType = "";
            BMS_Revision = "";
            PCBA_Revision = "";
            OrderStarted = 0;
            Assembly = 0;
            Rework = 0;
            Scrap = 0;
            Rollout = 0;
            Completed = 0;
            Status = 0;
        }

        [Key]
        public int PlanID { get; set; }
        public DateTime ProdDate { get; set; }
        public string Shift { get; set; }
        public int Lineid { get; set; }
        public int ShopId { get; set; }
        public string SKUId { get; set; }
        public int Plan { get; set; }
        public string OrderType { get; set; }
        public string BMS_Revision { get; set; }
        public string PCBA_Revision { get; set; }
        public int OrderStarted { get; set; }
        public int Assembly { get; set; }
        public int Rework { get; set; }
        public int Scrap { get; set; }
        public int Rollout { get; set; }
        public int Completed { get; set; }
        public int Status { get; set; }
    }
}
