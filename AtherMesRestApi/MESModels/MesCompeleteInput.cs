using System;

namespace AtherMesRestApi.MESModels
{
    public class MesCompeleteInput
    {
        public string RowID { get; set; }
        public string TimeStamp { get; set; }
        public string BIN { get; set; }
        public string Station { get; set; }
        public string Signal { get; set; }
        public string Message { get; set; }
        public int Value { get; set; }

    }
}
