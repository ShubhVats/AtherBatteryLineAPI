using System.ComponentModel.DataAnnotations;

namespace AtherMesRestApi.MESModels
{
    public class v_Config_User_Common
    {
        [Key]
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string UserPWD { get; set; }
        public string UserEmail { get; set; }
        public string UserMobile { get; set; }
        public int UserRole { get; set; }
        public string Token { get; set; }
    }

}
