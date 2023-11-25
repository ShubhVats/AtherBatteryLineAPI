using System;
using System.ComponentModel.DataAnnotations;

namespace AtherMesRestApi.MESModels
{
    public class Pref_SPRLoss
    {
        [Key]
        public int RowId { get; set; }
        public DateTime Timestamp { get; set; }
        public string StationName { get; set; }
        public int SPRcount { get; set; }








    }
}
