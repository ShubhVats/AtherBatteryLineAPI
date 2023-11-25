namespace AtherMesRestApi.MESModels
{
    public class VinCreate
    {

        public JiraVinIssue fields { get; set; }
        public class JiraVinIssue
        {
            public JiraVinProject project { get; set; }
            public string summary { get; set; }
            public JiraVinIssueType issuetype { get; set; }
            public string customfield_12319 { get; set; }
            public string customfield_20026 { get; set; }
            public string customfield_20005 { get; set; }

        }

        public class JiraVinProject
        {
            public string id { get; set; }
        }

        public class JiraVinIssueType
        {
            public string id { get; set; }
        }

    }
}
