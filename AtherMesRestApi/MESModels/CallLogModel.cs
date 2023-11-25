using System;

namespace AtherMesRestApi.MESModels
{
    public class CallLogModel
    {
        public CallLogModel(DateTime prodDate, string prodShift, int lineID, string stationID, string sENDER, string rECEIVER, DateTime startTime, DateTime aCKTime, DateTime endTime, int callStatus)
        {
            ProdDate = prodDate;
            ProdShift = prodShift;
            LineID = lineID;
            StationID = stationID;
            SENDER = sENDER;
            RECEIVER = rECEIVER;
            StartTime = startTime;
            ACKTime = aCKTime;
            EndTime = endTime;
            CallStatus = callStatus;
        }

        public int RowId { get; set; }
        public DateTime ProdDate { get; set; }
        public string ProdShift { get; set; }
        public int LineID { get; set; }
        public string StationID { get; set; }
        public string SENDER { get; set; }
        public string RECEIVER { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime ACKTime { get; set; }
        public DateTime EndTime { get; set; }
        public int CallStatus { get; set; }
    }
}

