using System.Collections.Generic;
using AtherMesRestApi.Controllers;

namespace AtherMesRestApi.MESModels
{
    public class RequestStations
    {
        public string bin_number { get; set; }
        public List<Stations> stations { get; set; }
    }
}
