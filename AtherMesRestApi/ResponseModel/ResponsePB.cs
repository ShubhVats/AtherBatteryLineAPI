namespace AtherMesRestApi.ResponseModel
{
    public class ResponsePB
    {
        public OrderP MT_ProdOrder_GR_Resp { get; set; }


        public class OrderP
        {
            public OrderPB response { get; set; }

        }
        public class OrderPB
        {
            public string production_Order_No { get; set; }
            public string messageType { get; set; }
            public string message { get; set; }

        }


    }
}

