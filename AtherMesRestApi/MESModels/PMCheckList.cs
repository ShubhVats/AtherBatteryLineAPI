using System;

namespace AtherMesRestApi.MESModels
{
    public class PMCheckList
    {
        public int AssetId { get; set; }
        public int CheckListId { get; set; }
        public string CheckListName { get; set; }
        public string CheckListDescription { get; set; }
        public int Phase { get; set; }
        public int AssetStatus { get; set; }
        public string SOPFilePath { get; set; }
        public string CheckPointId { get { return ""; } }
        public int SequenceNo { get { return 0; } }
        public int RowId { get; set; }
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
    }
}
