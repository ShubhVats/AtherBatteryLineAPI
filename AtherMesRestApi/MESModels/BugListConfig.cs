using System;
using System.Collections.Generic;

namespace AtherMesRestApi.MESModels
{
    public class BugListConfig
    {
        public Int64 Bug_ID { get; set; }
        public string Bug_Name { get; set; }
        public string Bug_Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public string LastUpdatedBy { get; set; }
    }
   
}
