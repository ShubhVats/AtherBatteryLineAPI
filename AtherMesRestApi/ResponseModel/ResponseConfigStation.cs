using System;
using AtherMesRestApi.MESModels;
using System.Collections.Generic;

namespace AtherMesRestApi.ResponseModel
{
    public class ResponseConfigStation
    {

            public string message { get; set; }
            public int status { get; set; }

            public List<StationMaster> data { get; set; }

            public ResponseConfigStation()
            {

            }

            public ResponseConfigStation(string msg, int status, List<StationMaster> data)
            {
                this.message = msg;
                this.status = status;
                this.data = data;
            }


        }
    }

