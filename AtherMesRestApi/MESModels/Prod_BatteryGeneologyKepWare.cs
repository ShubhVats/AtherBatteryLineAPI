﻿using System;

namespace AtherMesRestApi.MESModels
{
    public class Prod_BatteryGeneologyKepWare
    {

        public DateTime Timestamp { get; set; }
        public string BIN_Number { get; set; }
        public string StationName { get; set; }
        public string ParameterId { get; set; }
        public string ParameterVal { get; set; }
        public string Quality { get; set; }
        public int Status { get; set; }
    }
}
