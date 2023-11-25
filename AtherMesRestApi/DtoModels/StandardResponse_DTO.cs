using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtherMesRestApi.DtoModels
{
    public class StandardResponseProductionOrder
    {
        public string Production_Order_No { get; set; }
        public string MessageType { get; set; }
        public string Message { get; set; }
    }

    public class StandardResponseProductionOrder_Dto
    {
        public List<StandardResponseProductionOrder> Response { get; set; }

    }





}
