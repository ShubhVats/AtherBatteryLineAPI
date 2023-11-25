using System;
using System.ComponentModel.DataAnnotations;

namespace AtherMesRestApi.MESModels
{
    public class LoggedUser
    {
        public LoggedUser(DateTime timeStamp, DateTime proDate, string shift, string line, string stationNo, string assignedUser)
        {
            TimeStamp = timeStamp;
            ProDate = proDate;
            Shift = shift;
            Line = line;
            StationNo = stationNo;
            AssignedUser = assignedUser;
        }

        [Key]
        public DateTime TimeStamp { get; set; }
        public DateTime ProDate { get; set; }
        public string Shift { get; set; }
        public string Line { get; set; }
        public string StationNo { get; set; }
        public string AssignedUser { get; set; }
    }
}
