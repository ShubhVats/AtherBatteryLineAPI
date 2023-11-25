namespace AtherMesRestApi.MESModels
{
    public class JiraSendDataInput
    {
        public string Timestamp { get; set; }
        public string BIN_Number { get; set; }
        public string ProdShift { get; set; }
        public string Inserted_By { get; set; }
        public string LineName { get; set; }
        public string StationName { get; set; }
        public string Parameter_Value { get; set; }
        public string Parameter_Name { get; set; }
        public string CategoryName { get; set; }
        public string SubCategoryName { get; set; }
        public string Rework_Remark { get; set; }
        public string RSA_Remark { get; set; }
        public string OperatorRemark { get; set; }
        public string Bugid { get; set; }
        public string QIRemark { get; set; }
        public string Status { get; set; }
        public string IssueLogCreateRes { get; set; }
        public string IssueLogUpdateRes { get; set; }
    }
}
