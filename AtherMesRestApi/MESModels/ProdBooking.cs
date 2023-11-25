using System.Collections.Generic;

namespace AtherMesRestApi.MESModels
{
    public class ProdBooking
    {
        public List<Order> Prod_Order_GR { get; set; }


        public class Order
        {
            public string Prod_Order { get; set; }
            public string BIN { get; set; }
            public string LineID { get; set; }
            public int Status { get; set; }
            public List<Key_components> Key_components { get; set; }

        }
        public class Key_components
        {
            public string KeyComponent { get; set; }
            public string KeyComponent_ID { get; set; }
            public string KeyComponent_Type { get; set; }
        }


    }
}



