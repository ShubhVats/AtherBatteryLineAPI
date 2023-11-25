using System.ComponentModel.DataAnnotations;

namespace AtherMesRestApi.MESModels
{
    public class Config_Instance
    {

        [Key]
        public int CheckListId { get; set; }
        public int Instance { get; set; }

        public Config_Instance()
        {
        }

        public Config_Instance(int checkListId, int instance)
        {
            CheckListId = checkListId;
            Instance = instance;
        }

    }
}
