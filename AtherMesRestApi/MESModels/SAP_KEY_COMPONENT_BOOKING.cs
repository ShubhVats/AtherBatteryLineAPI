
using System;
using System.ComponentModel.DataAnnotations;

namespace AtherMesRestApi.MESModels
{
    public class SAP_KEY_COMPONENT_BOOKING
    {
        
        public SAP_KEY_COMPONENT_BOOKING()
        {
        }

        public SAP_KEY_COMPONENT_BOOKING(string production_Order_No, string bIN_Number, string key_Component_ID, string key_Component_Serial_No, string key_Component_Type)
        {
            Production_Order_No = production_Order_No;
            BIN_Number = bIN_Number;
            Key_Component_ID = key_Component_ID;
            Key_Component_Serial_No = key_Component_Serial_No;
            Key_Component_Type = key_Component_Type;
        }

        [Key]
        public Int64 UID { get; set; }
        public string Production_Order_No { get; set; }
        public string BIN_Number { get; set; }
        public string Key_Component_ID { get; set; }
        public string Key_Component_Serial_No { get; set; }
        public string Key_Component_Type { get; set; }

    }
}
