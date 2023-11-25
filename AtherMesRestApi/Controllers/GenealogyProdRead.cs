using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtherMesRestApi.MESModels;
using AtherMesRestApi.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AtherMesRestApi.Controllers
{
    [Route("api/geneologyprodserviceread")]
    [ApiController]
    public class GenealogyProdReadController : ControllerBase
    {
        private readonly MESDBContext _context;

        public GenealogyProdReadController(MESDBContext context)
        {
            _context = context;
        }

        [HttpPost("insertGenealogy")]
        public async Task<ActionResult<ResponseSave>> InsertParamValInGenealogy(BatteryDetails batteryDetails)
        {
            string status = string.Empty;
            ResponseSave responseSave;
            Prod_StationGeneology batteryDetailsGeneology;

            //Save only genealogy for FG params
            batteryDetailsGeneology = new(Convert.ToDateTime(batteryDetails.Timestamp), batteryDetails.BIN_Number, Int32.Parse(batteryDetails.StationId), batteryDetails.ParameterId, batteryDetails.ParameterVal, batteryDetails.Quality, 1);

            try
            {
                _context.Prod_StationGeneology.Add(batteryDetailsGeneology);
                await _context.SaveChangesAsync();
                status = "Success";

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                status = "Failed";

            }

            if (status == "Success")
            {
                responseSave = new ResponseSave("Data saved successfully!", 200);
            }
            else
            {
                responseSave = new ResponseSave("Data not saved.", 300);
            }

            return responseSave;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseProdGenealogyKepware>> GetGeneologyWithBinNumber(RequestStations requestStations)
        {
            ResponseProdGenealogyKepware responseProdGeneology;
            if (!requestStations.bin_number.Equals(""))
            {
                string bin_number = requestStations.bin_number;
                List<Stations> stations = requestStations.stations;

                List<Prod_BatteryGeneologyKepWare> parentList = new List<Prod_BatteryGeneologyKepWare>();
                parentList.Clear();



                for (int i = 0; i < stations.Count; i++)
                {
                    var GeneologyProdList = await _context.Prod_BatteryGeneologyKepWare.Where(a => a.BIN_Number.Equals(bin_number) && a.StationName.Equals(stations[i].station) && !a.ParameterId.Contains("D1"))
                                       .OrderBy(p => p.Timestamp).LastOrDefaultAsync();

                    if (GeneologyProdList != null)
                    {
                        if (GeneologyProdList.ParameterVal != null)
                        {
                            parentList.Add(GeneologyProdList);

                        }
                        else
                        {
                            GeneologyProdList.ParameterVal = "0";
                            parentList.Add(GeneologyProdList);
                        }
                    }

                }



                if (parentList == null)
                {
                    responseProdGeneology = new ResponseProdGenealogyKepware("data not found", 300, null);
                    //return NotFound();
                }

                else
                {
                    if (parentList.Count > 0)
                    {
                        responseProdGeneology = new ResponseProdGenealogyKepware("data found", 200, parentList);

                    }
                    else
                    {
                        responseProdGeneology = new ResponseProdGenealogyKepware("data not found", 300, null);

                    }

                }

                return responseProdGeneology;
            }
            else
            {
                responseProdGeneology = new ResponseProdGenealogyKepware("data not found", 300, null);
                return responseProdGeneology;

            }
        }

        [HttpGet("{binnumber}/{parameterid}")]
        public async Task<ActionResult<ResponseParameterValue>> GetParameter(string binnumber, string parameterid)
        {

            ResponseParameterValue parameterValue;
            List<Prod_BatteryGeneologyKepWare> parameter = new List<Prod_BatteryGeneologyKepWare>();
            if (parameterid == "D1130" || parameterid == "D1131")
            {
                parameter = await _context.Prod_BatteryGeneologyKepWare.Where(a => a.BIN_Number.Equals(binnumber) && a.ParameterId.Equals(parameterid) && a.ParameterVal != "1" && a.ParameterVal != "2" && a.Status == 0)
                        .ToListAsync();

            }
            else
            {
                parameter = await _context.Prod_BatteryGeneologyKepWare.Where(a => a.BIN_Number.Equals(binnumber) && a.ParameterId.Equals(parameterid))
                        .ToListAsync();

            }

            if (parameter.Count() == 0)
            {
                parameterValue = new ResponseParameterValue("data not found", 300, null);
                //return NotFound();
            }
            else
            {
                parameterValue = new ResponseParameterValue("data found", 200, parameter[parameter.Count - 1].ParameterVal);
            }

            return parameterValue;
        }

        [HttpGet("temp/{binnumber}/{parameterid}")]
        public async Task<ActionResult<ResponseParameterValue>> GetParameterTemp(string binnumber, string parameterid)
        {

            ResponseParameterValue parameterValue;
            List<Prod_CyclerTemptable> parameter = new List<Prod_CyclerTemptable>();
            if (parameterid == "D1130" || parameterid == "D1131")
            {
                parameter = await _context.Prod_CyclerTemptable.Where(a => a.BIN_Number.Equals(binnumber) && a.ParameterId.Equals(parameterid) && a.ParameterVal != "1" && a.ParameterVal != "2" && a.Status == 0)
                        .ToListAsync();

            }
            else
            {
                parameter = await _context.Prod_CyclerTemptable.Where(a => a.BIN_Number.Equals(binnumber) && a.ParameterId.Equals(parameterid))
                        .ToListAsync();

            }

            if (parameter.Count() == 0)
            {
                parameterValue = new ResponseParameterValue("data not found", 300, null);
                //return NotFound();
            }
            else
            {
                parameterValue = new ResponseParameterValue("data found", 200, parameter[parameter.Count - 1].ParameterVal);
            }

            return parameterValue;
        }


    }
}
