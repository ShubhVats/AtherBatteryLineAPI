using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtherMesRestApi.DtoModels
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Project
    {
        public int Id { get; set; }
    }

    public class Issuetype
    {
        public int Id { get; set; }
    }

    public class Fields
    {
        public Project Project { get; set; }
        public string Summary { get; set; }
        public Issuetype Issuetype { get; set; }
        public int Customfield_20026 { get; set; }
        public string Customfield_20005 { get; set; }
        public string Customfield_13459 { get; set; }
    }

    public class SapOrder_DTO
    {
        public List<Fields> Fields { get; set; }
    }


}
