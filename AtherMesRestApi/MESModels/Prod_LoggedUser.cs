using System;
using System.ComponentModel.DataAnnotations;

namespace AtherMesRestApi.MESModels
{
    public class Prod_LoggedUser
    {
        public Prod_LoggedUser(DateTime timestamp, DateTime prodDate, string prodshift, string department, string status, string stationName, string assignedUser)
        {
            Timestamp = timestamp;
            ProdDate = prodDate;
            Prodshift = prodshift;
            Department = department;
            Status = status;
            StationName = stationName;
            AssignedUser = assignedUser;
        }

        [Key]
        public int RowID { get; set; }
        public DateTime Timestamp { get; set; }
        public DateTime ProdDate { get; set; }
        public string Prodshift { get; set; }
        public string Department { get; set; }
        public string Status { get; set; }
        public string StationName { get; set; }
        public string AssignedUser { get; set; }
    }
}
