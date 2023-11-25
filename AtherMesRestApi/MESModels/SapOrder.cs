using System;
using System.Collections.Generic;

#nullable disable

namespace AtherMesRestApi.MESModels
{
    public partial class SapProductionOrder
    {
       
        public string Production_Order_No { get; set; }
        public string SKU { get; set; }
        public string SKU_Description { get; set; }
        public DateTime Prod_Date { get; set; }
        public string Prod_Shift { get; set; }
        public string Line_No { get; set; }
        public int Order_Quantity { get; set; }
        public string Cell_Type { get; set; }
        public string UOM { get; set; }
        public string Serial_No { get; set; }
        public int Status { get; set; }

    }


    public partial class SapProductionKeyComponents
    {
      
        public string Production_Order_Key_Component_Key { get; set; }
        public string Production_Order_No { get; set; }
        public string Key_Component { get; set; }
        public string Key_Component_Description { get; set; }
        public string Key_Component_Type { get; set; }


    }

    public partial class SapProductionKeyComponentsDto
    {
        public string Key_Component { get; set; }
        public string Key_Component_Description { get; set; }
        public string Key_Component_Type { get; set; }

    }

    public partial class SapProductionOrderDto
    {
        public string Production_Order_No { get; set; }
        public string SKU { get; set; }
        public string SKU_Description { get; set; }
        public DateTime Prod_Date { get; set; }
        public string Prod_Shift { get; set; }
        public string Line_No { get; set; }
        public int Order_Quantity { get; set; }
        public string Cell_Type { get; set; }

        public string UOM { get; set; }

        public string Serial_No { get; set; }
        public List<SapProductionKeyComponentsDto> KeyComponents { get; set; }

    }


    public  class NewSapProductionOrderDto
    {
        public List<SapProductionOrderDto> MesProductionOrders { get; set; }
    }


}
