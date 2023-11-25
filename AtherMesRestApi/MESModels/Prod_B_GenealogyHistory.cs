using System;
using System.ComponentModel.DataAnnotations;

namespace AtherMesRestApi.MESModels
{
    public class Prod_B_GenealogyHistory
    {
        [Key]
        public int ID { get; set; }
        public DateTime Timestamp { get; set; }
        public string BIN_Number { get; set; }
        public int StationId { get; set; }
        public string ParameterId { get; set; }
        public string ParameterVal { get; set; }
        public int Quality { get; set; }
        public int Status { get; set; }

    }
}
