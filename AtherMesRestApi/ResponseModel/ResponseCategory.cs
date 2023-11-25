using AtherMesRestApi.MESModels;
using System.Collections.Generic;

namespace AtherMesRestApi.ResponseModel
{
    public class ResponseCategory
    {
        public string message { get; set; }
        public int status { get; set; }

        public List<Category> data { get; set; }

        public ResponseCategory()
        {
            
        }

        public ResponseCategory(string msg, int status, List<Category> data)
        {
            this.message = msg;
            this.status = status;
            this.data = data;
        }


    }
}
