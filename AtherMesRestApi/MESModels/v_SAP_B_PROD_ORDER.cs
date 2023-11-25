using System;
using System.Security.Policy;

namespace AtherMesRestApi.MESModels
{
    public class v_SAP_B_PROD_ORDER
    {
        public Int64 UID { get; set; }
        public string Production_Order { get; set; }
        public string BIN_Number { get; set; }
        public string key_Component { get; set; }
        public string Key_Component_Type { get; set; }

    }
}
