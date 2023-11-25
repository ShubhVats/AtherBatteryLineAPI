using System;
using System.ComponentModel.DataAnnotations;

namespace AtherMesRestApi.MESModels
{
    public class Config_JHSchedule
    {
        public Config_JHSchedule(int rowId, int checkListID, int shiftID, int alert, DateTime dueDateTime, DateTime completionDateTime, string assignedUser, int status, DateTime createdOn, string createdBU, DateTime lastUpdatedOn, string lastUpdatedBy)
        {
            RowId = rowId;
            CheckListID = checkListID;
            ShiftID = shiftID;
            Alert = alert;
            DueDateTime = dueDateTime;
            CompletionDateTime = completionDateTime;
            AssignedUser = assignedUser;
            Status = status;
            CreatedOn = createdOn;
            CreatedBU = createdBU;
            LastUpdatedOn = lastUpdatedOn;
            LastUpdatedBy = lastUpdatedBy;
        }

        [Key]
        public int RowId { get; set; }
        public int CheckListID { get; set; }
        public int ShiftID { get; set; }
        public int Alert { get; set; }
        public DateTime DueDateTime { get; set; }
        public DateTime CompletionDateTime { get; set; }
        public string AssignedUser { get; set; }
        public int Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBU { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public string LastUpdatedBy { get; set; }
    }
}
