namespace AtherMesRestApi.MESModels
{
    public class UserLogin
    {
        public int StationId { get; set; }
        public string StationName { get; set; }
        public string UserID { get; set; }
        public string Username { get; set; }
        public string User_Role { get; set; }
        public string Token { get; set; }

    }
}
