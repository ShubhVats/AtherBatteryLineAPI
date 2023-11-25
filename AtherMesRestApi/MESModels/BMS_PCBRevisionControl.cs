using System.ComponentModel.DataAnnotations;

namespace AtherMesRestApi.MESModels
{
    public class BMS_PCBRevisionControl
    {
        [Key]
        public int UID { get; set; }
        public string SKU { get; set; }
        public string Part { get; set; }
        public string Revision { get; set; }
        public int Status { get; set; }
    }
}
