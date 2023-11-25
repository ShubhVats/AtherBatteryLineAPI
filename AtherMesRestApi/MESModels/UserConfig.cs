using System.ComponentModel.DataAnnotations;

namespace AtherMesRestApi.MESModels
{
    public class Config_User
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public string UserPWD { get; set; }
        public string UserEMail { get; set; }
        public string UserMobile { get; set; }
        public string Token { get; set; }
    }

}
