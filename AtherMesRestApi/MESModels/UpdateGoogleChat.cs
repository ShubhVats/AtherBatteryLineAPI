using System;

namespace AtherMesRestApi.MESModels
{

    public class UpdateGoogleChat
    {
        public UpdateGoogleChat(DateTime timestamp, int msg_Type, string line_No, string stationName, string assetid, int severity, string message, int mSGStatus)
        {
            Timestamp = timestamp;
            Msg_Type = msg_Type;
            Line_No = line_No;
            StationName = stationName;
            Assetid = assetid;
            Severity = severity;
            Message = message;
            MSGStatus = mSGStatus;
        }

        public int RowID { get; set; }
        public DateTime Timestamp { get; set; }
        public int Msg_Type { get; set; }
        public string Line_No { get; set; }
        public string StationName { get; set; }
        public string Assetid { get; set; }
        public int Severity { get; set; }
        public string Message { get; set; }
        public int MSGStatus { get; set; }

    }
   
}
