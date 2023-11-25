using System.Collections.Generic;

namespace AtherMesRestApi.MESModels
{
    public class ResponseQuality_DHCImage
    {
        public string message { get; set; }
        public int status { get; set; }

        public List<Quality_DHCImage> data { get; set; }

        public ResponseQuality_DHCImage()
        {

        }

        public ResponseQuality_DHCImage(string msg, int status, List<Quality_DHCImage> data)
        {
            this.message = msg;
            this.status = status;
            this.data = data;
        }


    }
}
