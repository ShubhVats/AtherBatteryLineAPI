using System;
using System.Collections.Generic;

namespace AtherMesRestApi.MESModels
{
    public class ReworkWIP
    {
        public int Line { get; set; }
        public string Station { get; set; }
        public int Operation { get; set; }
        public decimal OkNotOk { get; set; }
        public decimal Category { get; set; }
        public decimal SubCategory { get; set; }
        public string Description { get; set; }
        public string QualityDescription { get; set; }
        public int Shift { get; set; }
        public int Operator { get; set; }
        public DateTime Timestamp { get; set; }

    }
}

