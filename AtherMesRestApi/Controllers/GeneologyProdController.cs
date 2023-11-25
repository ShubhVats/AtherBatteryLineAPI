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
    [Route("api/geneologyprodservice")]
    [ApiController]
    public class GeneologyProdController : ControllerBase
    {
        private readonly MESDBContext _context;

        public GeneologyProdController(MESDBContext context)
        {
            _context = context;
        }

        //GET: api/SapOrders/5

        [HttpGet("{binnumber}/{parameterid}")]
        public async Task<ActionResult<ResponseParameterValue>> GetParameter(string binnumber, string parameterid)
        {

            ResponseParameterValue parameterValue;
            List<GeneologyProd> parameter = new List<GeneologyProd>();
            if (parameterid == "D1130" || parameterid == "D1131" || parameterid == "D1120" || parameterid == "D2004" || parameterid == "D2005")
            {
                parameter = await _context.GeneologyProd.Where(a => a.BIN_Number.Equals(binnumber) && a.ParameterId.Equals(parameterid) && a.ParameterVal != "1" && a.ParameterVal != "2" && a.Status == 0)
                        .ToListAsync();

            }
            else
            {
                parameter = await _context.GeneologyProd.Where(a => a.BIN_Number.Equals(binnumber) && a.ParameterId.Equals(parameterid))
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

        [HttpGet("fg/{binnumber}")]
        public async Task<ActionResult<ResponseFGPack>> GetFGReponse(string binnumber)
        {

            ResponseFGPack parameterValue;
            List<Prod_B_GenealogyHistory> parameterHistory = new List<Prod_B_GenealogyHistory>();
            List<Prod_B_GenealogyFG> parameterFG = new List<Prod_B_GenealogyFG>();
            List<Prod_B_WIPFG> WIPFG = new List<Prod_B_WIPFG>();
            List<Prod_B_WIPHistory> WIPHistory = new List<Prod_B_WIPHistory>();

            //string BMS = "D1130";
            //string PCBA = "D1131";

            string? respBMS = null, respPCBA = null;
            string respBMSRevision = "", respPCBARevision = "", respLine = "";
            int? respStatus = 0, respPlanId = 0;



            parameterFG = await _context.Prod_B_GenealogyFG.Where(a => a.BIN_Number.Equals(binnumber) && (a.ParameterId.Equals("D1130") || a.ParameterId.Equals("D2004")) && a.ParameterVal != "1" && a.ParameterVal != "2")
                                     .ToListAsync();
            if (parameterFG.Count > 0)
            {
                respBMS = parameterFG[0].ParameterVal;
            }
            parameterFG = await _context.Prod_B_GenealogyFG.Where(a => a.BIN_Number.Equals(binnumber) && (a.ParameterId.Equals("D1131") || a.ParameterId.Equals("D2005")) && a.ParameterVal != "1" && a.ParameterVal != "2")
                            .ToListAsync();
            if (parameterFG.Count > 0)
            {
                respPCBA = parameterFG[0].ParameterVal;
                respStatus = parameterFG[0].Status;
            }
            WIPFG = await _context.Prod_B_WIPFG.Where(a => a.BIN_Number.Equals(binnumber))
                        .ToListAsync();
            respLine = WIPFG[0].LineName;
            respPlanId = WIPFG[0].PlanID;

            if (respBMS == null || respPCBA == null)
            {
                parameterHistory = await _context.Prod_B_GenealogyHistory.Where(a => a.BIN_Number.Equals(binnumber) && (a.ParameterId.Equals("D1130") || a.ParameterId.Equals("D2004")) && a.ParameterVal != "1" && a.ParameterVal != "2")
                                     .ToListAsync();
                if (parameterHistory.Count > 0)
                {
                    respBMS = parameterHistory[0].ParameterVal;
                }
                parameterHistory = await _context.Prod_B_GenealogyHistory.Where(a => a.BIN_Number.Equals(binnumber) && (a.ParameterId.Equals("D1131") || a.ParameterId.Equals("D2005")) && a.ParameterVal != "1" && a.ParameterVal != "2")
                                      .ToListAsync();
                if (parameterHistory.Count > 0)
                {
                    respPCBA = parameterHistory[0].ParameterVal;
                    respStatus = parameterHistory[0].Status;
                }
                WIPHistory = await _context.Prod_B_WIPHistory.Where(a => a.BIN_Number.Equals(binnumber))
                                .ToListAsync();
                respLine = WIPHistory[0].LineName;
                respPlanId = WIPHistory[0].PlanID;

            }


            FGResponse response = new FGResponse();
            response.BMS = respBMS;
            response.PCBA = respPCBA;
            response.Status = respStatus;
            response.BMSRevision = respBMSRevision;
            response.PCBARevision = respPCBARevision;
            response.Line = respLine;
            response.PlanID = respPlanId;


            if (respBMS == null || respPCBA == null)
            {
                parameterValue = new ResponseFGPack("data not found", 300, null);
                //return NotFound();
            }
            else
            {
                parameterValue = new ResponseFGPack("data found", 200, response);
            }

            return parameterValue;
        }


        [HttpPost("insertGenealogy")]
        public async Task<ActionResult<ResponseSave>> InsertParamValInGenealogy(BatteryDetails batteryDetails)
        {
            string status = string.Empty;
            ResponseSave responseSave;
            BatteryDetailsGeneology batteryDetailsGeneology;

            List<BatteryDetailsGeneology> parameter = new List<BatteryDetailsGeneology>();


            //Save only genealogy for FG params
            if (batteryDetails.Status.Equals("2") || batteryDetails.Status.Equals("8") || batteryDetails.Status.Equals("1"))
            {
                parameter = await _context.BatteryDetailsGeneology.Where(a => a.BIN_Number.Equals(batteryDetails.BIN_Number) && a.ParameterId.Equals(batteryDetails.ParameterId) && a.Status == 0)
                  .ToListAsync();
                if (parameter != null && parameter.Count > 0)
                {
                    //Update logic need to add
                    //String param = parameter.ElementAt(0).ParameterVal.ToString();
                    //parameter.ForEach(a => a.ParameterVal = batteryDetails.ParameterVal);
                    foreach (BatteryDetailsGeneology param in parameter)
                    {
                        param.ParameterVal = batteryDetails.ParameterVal;
                        //await _context.SaveChangesAsync();
                    }

                }
                else
                {
                    batteryDetailsGeneology = new(Convert.ToDateTime(batteryDetails.Timestamp), batteryDetails.BIN_Number, Int32.Parse(batteryDetails.StationId), batteryDetails.ParameterId, batteryDetails.ParameterVal, batteryDetails.Quality, 0);
                    _context.BatteryDetailsGeneology.Add(batteryDetailsGeneology);
                }


            }
            else
            {
                batteryDetailsGeneology = new(Convert.ToDateTime(batteryDetails.Timestamp), batteryDetails.BIN_Number, Int32.Parse(batteryDetails.StationId), batteryDetails.ParameterId, batteryDetails.ParameterVal, batteryDetails.Quality, 1);
                _context.BatteryDetailsGeneology.Add(batteryDetailsGeneology);
            }

            await _context.SaveChangesAsync();
            status = "Success";

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
        public async Task<ActionResult<ResponseProdGeneology>> GetGeneologyWithBinNumber(RequestStations requestStations)
        {
            ResponseProdGeneology responseProdGeneology;
            if (!requestStations.bin_number.Equals(""))
            {
                string bin_number = requestStations.bin_number;
                List<Stations> stations = requestStations.stations;

                List<GeneologyProd> parentList = new List<GeneologyProd>();
                parentList.Clear();



                for (int i = 0; i < stations.Count; i++)
                {
                    var GeneologyProdList = await _context.GeneologyProd.Where(a => a.BIN_Number.Equals(bin_number) && a.StationName.Equals(stations[i].station) && !a.ParameterId.Contains("D1"))
                                       .OrderBy(p => p.Timestamp).LastOrDefaultAsync();

                    if (GeneologyProdList != null)
                    {
                        parentList.Add(GeneologyProdList);
                    }

                }



                if (parentList == null)
                {
                    responseProdGeneology = new ResponseProdGeneology("data not found", 300, null);
                    //return NotFound();
                }

                else
                {
                    if (parentList.Count > 0)
                    {
                        responseProdGeneology = new ResponseProdGeneology("data found", 200, parentList);

                    }
                    else
                    {
                        responseProdGeneology = new ResponseProdGeneology("data not found", 300, null);

                    }

                }

                return responseProdGeneology;
            }
            else
            {
                responseProdGeneology = new ResponseProdGeneology("data not found", 300, null);
                return responseProdGeneology;

            }
        }

        [HttpGet("laststation/{binnumber}")]
        public async Task<ActionResult<ResponseProdGeneology>> GetLastDHCStation(string binnumber)
        {

            ResponseProdGeneology response;
            List<GeneologyProd> parameter = new List<GeneologyProd>();
            String Error = "";

            try
            {
                var item = await _context.GeneologyProd.Where(a => a.BIN_Number.Equals(binnumber) && a.ParameterId.Equals("D2001"))
                    //.OrderBy(a=>a.Timestamp)
                    .ToListAsync();
                if (item != null)
                {
                    parameter.Add(item[item.Count-1]);
                }
            }

            catch (Exception e)
            {
                Error = e.Message.ToString();
            }

            if (parameter == null)
            {
                response = new ResponseProdGeneology("Data not found. Error: " + Error, 300, null);
            }
            else
            {
                if (parameter.Count > 0)
                {
                    response = new ResponseProdGeneology("Data found.", 200, parameter);

                }
                else
                {
                    response = new ResponseProdGeneology("Data not found.", 300, null);
                }
            }

            return response;
        }


        [HttpPost("insertNewGenealogy")]
        public async Task<ActionResult<ResponseSave>> InsertNewParamValInGenealogy(BatteryDetails batteryDetails)
        {
            string status = string.Empty;
            ResponseSave responseSave;
            BatteryDetailsGeneology batteryDetailsGeneology;

            try {
            
                batteryDetailsGeneology = new(Convert.ToDateTime(batteryDetails.Timestamp), batteryDetails.BIN_Number, Int32.Parse(batteryDetails.StationId), batteryDetails.ParameterId, batteryDetails.ParameterVal, batteryDetails.Quality, 0);
                _context.BatteryDetailsGeneology.Add(batteryDetailsGeneology);
                await _context.SaveChangesAsync();
                status = "Success";

            }
            
            catch(Exception ex)
            {
                
                status = "Error: "+ ex;

            }


            if (status == "Success")
            {
                responseSave = new ResponseSave("Data saved successfully!", 200);
            }
            else
            {
                responseSave = new ResponseSave("Data not saved."+status, 300);
            }

            return responseSave;
        }

    }
}
