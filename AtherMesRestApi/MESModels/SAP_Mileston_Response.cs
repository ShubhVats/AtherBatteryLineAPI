using System;
using System.ComponentModel.DataAnnotations;

namespace AtherMesRestApi.MESModels
{
    public class SAP_Mileston_Response
    {
        [Key]
        public int RowId { get; set; }
        public string Prod_Order_No { get; set; }
        public string BIN_Number { get; set; }
        public string MilestoneId { get; set; }
        public string MessageType { get; set; }
        public string Message { get; set; }
        public string ResponseBody { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
