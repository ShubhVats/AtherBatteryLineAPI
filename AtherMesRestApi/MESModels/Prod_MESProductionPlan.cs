using System;
using System.ComponentModel.DataAnnotations;
namespace AtherMesRestApi.MESModels
{
    public class Prod_MESProductionPlan
    {
        [Key]
        public Int64 UID { get; set; }
        public string Production_Order_No { get; set; }
        public string SKUId { get; set; }
        public DateTime Prod_Date { get; set; }
        public string Prod_Shift { get; set; }
        public string LineName { get; set; }
        public int Order_Quantity { get; set; }
        public string UOM { get; set; }
        public string Cell_Type { get; set; }
        public string BIN_Number { get; set; }
        public string Serial_No { get; set; }
        public int Status { get; set; }
        public DateTime Created_Date { get; set; }
    }
}
