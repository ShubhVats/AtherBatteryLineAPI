using System;

namespace AtherMesRestApi.MESModels
{
    public class GoogleChat
    {
        public string Timestamp { get; set; }   
        public string Msg_Type { get; set; }
        public string Line_No { get; set; }
        public string StationName { get; set; }
        public string Assetid { get; set; }
        public string Severity { get; set; }
        public string Message { get; set; }
        public string MSGStatus { get; set; }


    }
}
