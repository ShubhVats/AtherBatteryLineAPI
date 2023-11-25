using System;
using System.ComponentModel.DataAnnotations;

namespace AtherMesRestApi.MESModels
{

    public class Quality_DHCImage
    {


        [Key]
        public int RowID { get; set; }
        public DateTime Timestamp { get; set; }
        public string BIN_Number { get; set; }
        public string UserID { get; set; }
        public string LineName { get; set; }
        public string StationID { get; set; }
        public string ImagePath { get; set; }
        public bool IsDelete { get; set; }


    }

}

