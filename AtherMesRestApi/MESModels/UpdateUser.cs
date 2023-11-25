namespace AtherMesRestApi.MESModels
{
    public class UpdateUser
    {
        public int stationId { get; set; }
        public string userID { get; set; }
        public string line { get; set; }
        public UserLogin user { get; set; }

    }
}
