using System;
using System.ComponentModel.DataAnnotations;

namespace AtherMesRestApi.MESModels
{
    public class JIRA_Send_Data
    {
        public JIRA_Send_Data(DateTime timestamp, string prodShift, string inserted_By, string bIN_Number, string lineName, string stationName, string parameter_Value, string parameter_Name, string categoryName, string subCategoryName, string rework_Remark, string rSA_Remark, string operatorRemark, string bugid, string qIRemark, int status, string issueLogCreateRes, string issueLogUpdateRes)
        {
            Timestamp = timestamp;
            ProdShift = prodShift;
            Inserted_By = inserted_By;
            BIN_Number = bIN_Number;
            LineName = lineName;
            StationName = stationName;
            Parameter_Value = parameter_Value;
            Parameter_Name = parameter_Name;
            CategoryName = categoryName;
            SubCategoryName = subCategoryName;
            Rework_Remark = rework_Remark;
            RSA_Remark = rSA_Remark;
            OperatorRemark = operatorRemark;
            Bugid = bugid;
            QIRemark = qIRemark;
            Status = status;
            IssueLogCreateRes = issueLogCreateRes;
            IssueLogUpdateRes = issueLogUpdateRes;
        }

        [Key]
        public int RowId { get; set; }
        public DateTime Timestamp { get; set; }
        public string ProdShift { get; set; }
        public string Inserted_By { get; set; }
        public string BIN_Number { get; set; }
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
        public int Status { get; set; }
        public string IssueLogCreateRes { get; set; }
        public string IssueLogUpdateRes { get; set; }
        public string Ticket_Number { get; set; }
        public string ResponseBody { get; set; }

    }
}
