using System;

namespace AtherMesRestApi.MESModels
{
    public class BatteryWIP
    {


        public BatteryWIP()
        {
        }

        public BatteryWIP(string bIN_Number, string lineName, DateTime startTime, DateTime endTime, int reEntryStation, int status, int saveFlag, string stationName)
        {
            BIN_Number = bIN_Number;
            LineName = lineName;
            StartTime = startTime;
            EndTime = endTime;
            ReEntryStation = reEntryStation;
            Status = status;
            SaveFlag = saveFlag;
            StationName = stationName;

        }

        public Int64 RowId { get; set; }
        public string BIN_Number { get; set; }
        public string LineName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int ReEntryStation { get; set; }
        public int Status { get; set; }
        public int SaveFlag { get; set; }
        public string StationName { get; set; }
        public int PlanID { get; set; }
        public string SKUId { get; set; }

    }
}
