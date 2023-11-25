using System;
using System.ComponentModel.DataAnnotations;

namespace AtherMesRestApi.MESModels
{
    public class Config_UserAssigment
    {
        public Config_UserAssigment(string userID, string userName, string prodShift, DateTime startDate, DateTime endDate, int lineID, string stationName, DateTime timestamp)
        {
            UserID = userID;
            UserName = userName;
            ProdShift = prodShift;
            StartDate = startDate;
            EndDate = endDate;
            LineID = lineID;
            StationName = stationName;
            Timestamp = timestamp;
        }

        [Key]
        public int RowId { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string ProdShift { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LineID { get; set; }
        public string StationName { get; set; }
        public DateTime Timestamp { get; set; }

    }
}
