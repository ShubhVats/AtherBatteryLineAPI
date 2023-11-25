using System;

namespace AtherMesRestApi.MESModels
{
    public class MobileTerminalConfig
    {
        public int DeviceId { get; set; }
        public string IMEI_Number { get; set; }
        public string MACAddress { get; set; }
        public string StaticIP { get; set; }
        public int LineID { get; set; }
        public int StationID { get; set; }
        public string StationName { get; set; }
        public string DeviceDescription { get; set; }
        public int Status { get; set; }
        public int Type { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime lastUpdatedOn { get; set; }
        public string lastUpdatedBy { get; set; }
        public string ReworkStation { get; set; }
    }

}
