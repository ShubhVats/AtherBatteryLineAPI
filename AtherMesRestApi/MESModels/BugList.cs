using System.Collections.Generic;

namespace AtherMesRestApi.MESModels
{
    public class JiraSearch
    {
        public string jql { get; set; }
        public int startAt { get; set; }
        public int maxResults { get; set; }
        public List<string> fields { get; set; }

        public JiraSearch()
        {
            fields = new List<string>();
        }

        public JiraSearch(string jql, int startAt, int maxResults, List<string> fields)
        {
            this.jql = jql;
            this.startAt = startAt;
            this.maxResults = maxResults;
            this.fields = fields;
        }
    }

}

