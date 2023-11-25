using System.Collections.Generic;

namespace AtherMesRestApi.ResponseModel
{
    public class ResponseJiraSearch
    {
        public string expand { get; set; }
        public int startAt { get; set; }
        public int maxResults { get; set; }
        public int total { get; set; }
        public List<singleBug> issues { get; set; }

        public class singleBug
        {
            public string expand { get; set; }
            public string id { get; set; }
            public string self { get; set; }
            public string key { get; set; }
            public summaryJira fields { get; set; }
            public class summaryJira
            {
                public string summary { get; set; }
            }
        }

    }

    public class ReponseJIRASearchSQL
    {
        public string id { get; set; }
        public string key { get; set; }
        public string summary { get; set; }

        public ReponseJIRASearchSQL(string id, string key, string summary)
        {
            this.id = id;
            this.key = key;
            this.summary = summary;
        }

    }

}
