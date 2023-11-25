using System.Collections.Generic;

namespace AtherMesRestApi.MESModels
{
    public class CheckpointsVals
    {
        public List<singlePoint> fields { get; set; }
        public class singlePoint
        {
            public string CheckPoint { get; set; }
            public int CheckList { get; set; }
        }


    }
}
