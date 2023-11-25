using System.ComponentModel.DataAnnotations;

namespace AtherMesRestApi.MESModels
{
    public class Prod_Execute_JHCheckList
    {
        public Prod_Execute_JHCheckList(int checkListId, string checkPointId, int checkPointStatus, string checkPointValue, string remark)
        {

            CheckListId = checkListId;
            CheckPointId = checkPointId;
            CheckPointStatus = checkPointStatus;
            CheckPointValue = checkPointValue;
            Remark = remark;
        }

        [Key]
        public int RowId { get; set; }
        public int CheckListId { get; set; }
        public string CheckPointId { get; set; }
        public int CheckPointStatus { get; set; }
        public string CheckPointValue { get; set; }
        public string Remark { get; set; }

    }
}
