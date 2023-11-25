using System;
using System.ComponentModel.DataAnnotations;

namespace AtherMesRestApi.MESModels
{
    public class ShiftInformation
    {
        [Key]
        public int ShiftReset { get; set; }
        public string RunningSession { get; set; }
        public DateTime ProductionDate { get; set; }
        public string RunningOrder { get; set; }
        public string RunningSKU { get; set; }
        public string ProductionRunning { get; set; }
        public DateTime ShiftStart { get; set; }
        public DateTime ShiftEnd { get; set; }
        public int ShiftId { get; set; }
        public string ShiftName { get; set; }
        public int NPD { get; set; }
    }
}
