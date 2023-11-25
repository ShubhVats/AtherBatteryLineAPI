using System.Collections.Generic;
using AtherMesRestApi.MESModels;

namespace AtherMesRestApi.ResponseModel
{
    public class ResponseProdGenealogyKepware
    {
        public string message { get; set; }
        public int status { get; set; }

        public List<Prod_BatteryGeneologyKepWare> data { get; set; }

        public ResponseProdGenealogyKepware()
        {

        }

        public ResponseProdGenealogyKepware(string msg, int status, List<Prod_BatteryGeneologyKepWare> data)
        {
            this.message = msg;
            this.status = status;
            this.data = data;
        }


    }
}
