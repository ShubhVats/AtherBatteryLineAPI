namespace AtherMesRestApi.MESModels
{
    public class IPQCVal
    {
        public IPQCVal(string userValue, string remark)
        {
            this.userValue = userValue;
            this.remark = remark;
        }

        public string userValue { get; set; }
        public string remark { get; set; }

    }
}
