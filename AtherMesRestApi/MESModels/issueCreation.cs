namespace AtherMesRestApi.MESModels
{
    public class issueCreation
    {
        public JiraIssueIssue fields { get; set; }
        public class JiraIssueIssue
        {
            public JiraIssueProject project { get; set; }
            public string summary { get; set; }
            public string description { get; set; }
            public JiraIssueIssueType issuetype { get; set; }
            public JiraIssueRole customfield_13145 { get; set; }
            public JiraIssueShift customfield_13151 { get; set; }
            public string customfield_12716 { get; set; }
            public JiraIssueBinTicket customfield_24313 { get; set; }
            public JiraIssueBug customfield_24312 { get; set; }
        }

        public class JiraIssueProject
        {
            public string id { get; set; }
        }

        public class JiraIssueIssueType
        {
            public string id { get; set; }
        }
        public class JiraIssueRole
        {
            public string value { get; set; }
        }
        public class JiraIssueShift
        {
            public string value { get; set; }
        }
        public class JiraIssueBinTicket
        {
            public string key { get; set; }
        }
        public class JiraIssueBug
        {
            public string key { get; set; }
        }
    }
}
