using System;
using System.ComponentModel.DataAnnotations;
using NuGet.Packaging.Signing;

namespace AtherMesRestApi.MESModels
{

    public class SAP_JIRA_Response
    {
        [Key]
        public DateTime Timestamp { get; set; }
        public string Prod_Order_No { get; set; }
        public string BIN_Number { get; set; }
        public string JIRAticketNumber { get; set; }
        public string ResponseBody { get; set; }

    }
}

