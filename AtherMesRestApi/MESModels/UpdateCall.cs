using System;

namespace AtherMesRestApi.MESModels
{
    public class UpdateCall
    {
        public string receiver { get; set; }
        public string stationID { get; set; }
        public string rowId { get; set; }
        public string ackTime { get; set; }
        public string endTime { get; set; }
        public string callStatus { get; set; }
    }
}
