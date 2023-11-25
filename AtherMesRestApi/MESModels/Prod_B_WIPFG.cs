using System;
using System.ComponentModel.DataAnnotations;

namespace AtherMesRestApi.MESModels
{
    public class Prod_B_WIPFG
    {
        [Key]
        public Int64 RowId { get; set; }
        public int PlanID { get; set; }
        public string BIN_Number { get; set; }
        public string LineName { get; set; }
        public string SKUId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int ReEntryStation { get; set; }
        public int Status { get; set; }
        public int SaveFlag { get; set; }
        public string StationName { get; set; }

    }
}
