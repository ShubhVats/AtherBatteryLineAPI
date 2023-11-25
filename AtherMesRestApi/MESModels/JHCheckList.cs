using System;

namespace AtherMesRestApi.MESModels
{
    public class JHCheckList
    {
        private string name;
        public int LineId { get; set; }
        public int CheckListId { get; set; }
        public string CheckListName { get; set; }
        public string CheckListDescription { get; set; }
        public string SOPFilePath { get; set; }

        public string CheckPointId
        {
            get { return ""; }
        }
        public int SequenceNo
        {
            get { return 0; }
        }
        public int RowId { get; set; }
        public int ShiftID { get; set; }
        public int Alert { get; set; }
        public DateTime DueDateTime { get; set; }
        public DateTime CompletionDateTime { get; set; }
        public string AssignedUser { get; set; }
        public int Status { get; set; }
        public int StationId { get; set; }

    }
}
