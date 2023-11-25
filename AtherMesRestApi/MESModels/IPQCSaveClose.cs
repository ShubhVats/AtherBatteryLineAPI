namespace AtherMesRestApi.MESModels
{
    public class IPQCSaveClose
    {
        public IPQCSaveClose(int checkListId, string checkPointId, int checkPointStatus, string checkPointValue, string remark, int instance)
        {
            CheckListId = checkListId;
            CheckPointId = checkPointId;
            CheckPointStatus = checkPointStatus;
            CheckPointValue = checkPointValue;
            Remark = remark;
            Instance = instance;
        }

        public int RowId { get; set; }
        public int CheckListId { get; set; }
        public string CheckPointId { get; set; }
        public int CheckPointStatus { get; set; }
        public string CheckPointValue { get; set; }
        public string Remark { get; set; }
        public int Instance { get; set; }


    }
}
