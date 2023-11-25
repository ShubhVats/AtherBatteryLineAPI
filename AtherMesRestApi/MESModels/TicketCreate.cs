namespace AtherMesRestApi.MESModels
{
    public class TicketCreate
    {
        public JiraIssue fields { get; set; }
        public class JiraIssue
        {
            public JiraProject project { get; set; }
            public string summary { get; set; }
            public JiraIssueType issuetype { get; set; }
            public string customfield_13459 { get; set; }
            public long customfield_20026 { get; set; }
        }

        public class JiraProject
        {
            public string id { get; set; }
        }

        public class JiraIssueType
        {
            public string id { get; set; }
        }

    }
}