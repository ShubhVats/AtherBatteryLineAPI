namespace AtherMesRestApi.MESModels
{
    public class issueUpdate
    {
        public string Id { get; set; }
        public JiraIssueUpdate fields { get; set; }


    }
    public class JiraIssueUpdateInternal
    {
        public JiraIssueUpdate fields { get; set; }

    }
    public class JiraIssueUpdate
    {
        public string description { get; set; }
    }


}
