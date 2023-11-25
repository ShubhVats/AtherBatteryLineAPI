using System;

namespace AtherMesRestApi.MESModels
{
    public class CheckList
    {
        public int CheckListId { get; set; }
        public DateTime StartDateTime { get; set; }
        public int FrequencyType { get; set; }
        public int FrequencyValue { get; set; }
        public Int64 FrequencyDuration { get; set; }
        public int Alert { get; set; }
        public int EstimatedDuration { get; set; }
        public DateTime CompletonDateTime { get; set; }
        public DateTime DueDateTime { get; set; }
        public string AssignedUser { get; set; }
        public int Status { get; set; }
        public string Part_Number_with_rev { get; set; }
        public string Part_Name_Description { get; set; }
        public string Module_Line_No { get; set; }
        public string Part_Criticality { get; set; }
        public string IPIS_No { get; set; }
        public string CPRef { get; set; }
        public string Customer { get; set; }
        public string Model { get; set; }
        public int LineId { get; set; }
        public string CheckListName { get; set; }
        public string CheckListDescription { get; set; }
        public string SOPFilePath { get; set; }
        public int CheckListType { get; set; }
        public string Phase { get; set; }

    }
}
