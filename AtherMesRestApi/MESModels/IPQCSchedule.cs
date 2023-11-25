using System;
using System.ComponentModel.DataAnnotations;

namespace AtherMesRestApi.MESModels
{
    public class Config_IPQCSchedule
    {
        [Key]
        public int RowId { get; set; }
        public int CheckListId { get; set; }
        public DateTime StartDateTime { get; set; }
        public int FrequencyType { get; set; }
        public int FrequencyValue { get; set; }
        public Int64 FrequencyDuration { get; set; }
        public int Alert { get; set; }
        public int EstimatedDuration { get; set; }
        public DateTime DueDateTime { get; set; }
        public DateTime CompletonDateTime { get; set; }
        public string AssignedUser { get; set; }
        public int Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public string LastUpdatedBy { get; set; }
    }
}
