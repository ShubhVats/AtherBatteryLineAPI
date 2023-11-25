using System.ComponentModel.DataAnnotations;

namespace AtherMesRestApi.MESModels
{
    public class Config_JHCheckPoint
    {

        [Key]
        public string CheckPointId { get; set; }
        public string CheckPointName { get; set; }
        public int CheckListId { get; set; }
        public int Category { get; set; }
        public decimal EstimatedDuration { get; set; }
        public string UOM { get; set; }
        public int CheckPointType { get; set; }
        public int Criticality { get; set; }

    }
}
