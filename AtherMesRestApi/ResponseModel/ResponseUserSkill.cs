using AtherMesRestApi.MESModels;
using System.Collections.Generic;

namespace AtherMesRestApi.ResponseModel
{
    public class ResponseUserSkill
    {
        public string message { get; set; }
        public int status { get; set; }

        public List<UserSkill> data { get; set; }

        public ResponseUserSkill()
        {
            
        }

        public ResponseUserSkill(string msg, int status, List<UserSkill> data)
        {
            this.message = msg;
            this.status = status;
            this.data = data;
        }


    }
}
