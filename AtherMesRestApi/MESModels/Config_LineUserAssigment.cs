using System;
using System.ComponentModel.DataAnnotations;

namespace AtherMesRestApi.MESModels
{
    public class Config_LineUserAssigment
    {
        public Config_LineUserAssigment(DateTime timestamp, DateTime prodDate, string prodShift, string stationName, string assignedUserID, string assignedUserName, int department, int userRole, int status)
        {
            Timestamp = timestamp;
            ProdDate = prodDate;
            ProdShift = prodShift;
            StationName = stationName;
            AssignedUserID = assignedUserID;
            AssignedUserName = assignedUserName;
            Department = department;
            UserRole = userRole;
            Status = status;
        }

        [Key]
        public int RowId { get; set; }
        public DateTime Timestamp { get; set; }
        public DateTime ProdDate { get; set; }
        public string ProdShift { get; set; }
        public string StationName { get; set; }
        public string AssignedUserID { get; set; }
        public string AssignedUserName { get; set; }
        public int Department { get; set; }
        public int UserRole { get; set; }
        public int Status { get; set; }
    }
}
