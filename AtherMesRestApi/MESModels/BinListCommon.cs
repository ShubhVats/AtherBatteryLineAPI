using System;

namespace AtherMesRestApi.MESModels
{
    public class BinListCommon
    {
        public string BIN_Number { get; set; }
        public int Status { get; set; }
        public string StationName { get; set; }
        public int SaveFlag { get; set; }
        public string ReworkStationName { get; set; }
        public DateTime EndTime { get; set; }
    }
}
