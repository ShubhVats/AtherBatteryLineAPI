using System;
using System.ComponentModel.DataAnnotations;

namespace AtherMesRestApi.MESModels
{
    public class Category
    {
        public int Category_ID { get; set; }
        public string Category_Name { get; set; }
        public string Category_Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public string LastUpdatedBy { get; set; }
    }
}
