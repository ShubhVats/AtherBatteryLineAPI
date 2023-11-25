using System;
using System.ComponentModel.DataAnnotations;

namespace AtherMesRestApi.MESModels
{
    public class Prod_BatteryWIPLineCommon
    {


        public Prod_BatteryWIPLineCommon()
        {
        }

        public Prod_BatteryWIPLineCommon(string bIN_Number, string lineName, DateTime startTime, DateTime endTime, int reEntryStation, int status, int saveFlag, string stationName, int planID, string reworkStationName)
        {
            BIN_Number = bIN_Number;
            LineName = lineName;
            StartTime = startTime;
            EndTime = endTime;
            ReEntryStation = reEntryStation;
            Status = status;
            SaveFlag = saveFlag;
            StationName = stationName;
            PlanID = planID;
            ReworkStationName = reworkStationName;
        }

        [Key]
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
        public string ReworkStationName { get; set; }

    }
}
