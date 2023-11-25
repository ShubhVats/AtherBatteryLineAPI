using System;
using System.ComponentModel.DataAnnotations;

namespace AtherMesRestApi.MESModels
{
    public class MesCompelete
    {
        public MesCompelete(DateTime timeStamp, string bIN, string station, string message,int value)
        {
            TimeStamp = timeStamp;
            BIN = bIN;
            Station = station;
            Message = message;
            Value= value;
        }

        [Key]
        public int RowID { get; set; }
        public DateTime TimeStamp { get; set; }
        public string BIN { get; set; }
        public string Station { get; set; }
        public string Message { get; set; }

        public int Value { get; set; }
    }
}
