using System.ComponentModel.DataAnnotations;

namespace AtherMesRestApi.MESModels
{
    public class Config_Instance_PM
    {

        [Key]
        public int CheckListId { get; set; }
        public int Instance { get; set; }

        public Config_Instance_PM()
        {
        }

        public Config_Instance_PM(int checkListId, int instance)
        {
            CheckListId = checkListId;
            Instance = instance;
        }

    }
}
