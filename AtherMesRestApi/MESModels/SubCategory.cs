using System;

namespace AtherMesRestApi.MESModels
{
    public class SubCategory
    {
        public int Category_ID { get; set; }
        public int SubCategory_ID { get; set; }
        public string SubCategory_Name { get; set; }
        public string SubCategory_Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public string LastUpdatedBy { get; set; }


    }
}
