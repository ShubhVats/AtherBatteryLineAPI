using AtherMesRestApi.MESModels;
using System.Collections.Generic;

namespace AtherMesRestApi.ResponseModel
{
    public class ResponseSubCategory
    {
        public string message { get; set; }
        public int status { get; set; }

        public List<SubCategory> data { get; set; }

        public ResponseSubCategory()
        {
            
        }

        public ResponseSubCategory(string msg, int status, List<SubCategory> data)
        {
            this.message = msg;
            this.status = status;
            this.data = data;
        }


    }
}
