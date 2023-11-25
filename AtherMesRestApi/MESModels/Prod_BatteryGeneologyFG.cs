using System;
using System.ComponentModel.DataAnnotations;

namespace AtherMesRestApi.MESModels
{
    public class Prod_B_GenealogyFG
    {
        public Prod_B_GenealogyFG(DateTime timestamp, string bIN_Number, int stationId, string parameterId, string parameterVal, string quality, int status)
        {
            Timestamp = timestamp;
            BIN_Number = bIN_Number;
            StationId = stationId;
            ParameterId = parameterId;
            ParameterVal = parameterVal;
            Quality = quality;
            Status = status;
        }

        [Key]
        public int ID { get; set; }
        public DateTime Timestamp { get; set; }
        public string BIN_Number { get; set; }
        public int StationId { get; set; }
        public string ParameterId { get; set; }
        public string ParameterVal { get; set; }
        public string Quality { get; set; }
        public int Status { get; set; }

    }
}
