namespace AtherMesRestApi.MESModels
{
    public class CallLog
    {
        public int RowId { get; set; }
        public string LineID { get; set; }
        public string StationID { get; set; }
        public string SENDER { get; set; }
        public string RECEIVER { get; set; }
        public string StartTime { get; set; }
        public string ACKTime { get; set; }
        public string EndTime { get; set; }
        public string CallStatus { get; set; }
        public string BinNumber { get; set; }
    }
}

