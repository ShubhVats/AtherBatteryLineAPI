using System;
using System.ComponentModel.DataAnnotations;

namespace AtherMesRestApi.MESModels
{

    public class Prod_ReworkGeneology
    {
        public static DateTime d = DateTime.Now;


        [Key]
        public int RowID { get; set; }
        public DateTime Timestamp { get; set; } = d;
        public string LineName { get; set; }
        public string StationID { get; set; }
        public string ParameterId { get; set; }
        public string ParameterDescription { get; set; }
        public string DHCParameterID { get; set; }
        public string BIN_Number { get; set; }
        public string ParameterVal { get; set; }
    }
}

