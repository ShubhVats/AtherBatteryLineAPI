using System;

namespace AtherMesRestApi.MESModels
{
    public class StatusGenealogy
    {
        public StatusGenealogy()
        {
        }

        public int Rowid { get; set; }
        public DateTime Proddate { get; set; }

        public string ProdShift { get; set; }

        public DateTime Timestamp { get; set; }

        public string BIN_Number { get; set; }

        public string SKU { get; set; } 

        public Int64 StationId { get; set;}

        public Int64 Status { get; set; }

        public StatusGenealogy(DateTime proddate, string prodShift, DateTime timestamp, string bIN_Number, string sKU, long stationId, long status)
        {
            Proddate = proddate;
            ProdShift = prodShift;
            Timestamp = timestamp;
            BIN_Number = bIN_Number;
            SKU = sKU;
            StationId = stationId;
            Status = status;
        }
    }
}
