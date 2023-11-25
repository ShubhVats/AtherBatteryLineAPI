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
    [Route("api")]
    [ApiController]

    public class SaveBatteryController : ControllerBase
    {
        private readonly MESDBContext _context;

        public SaveBatteryController(MESDBContext context)
        {
            _context = context;
        }

        [HttpPost("saveplanid")]
        public async Task<ResponseSave> SavePlanId(List<BatteryDetails> batteryDetailsList)
        {
            string status = string.Empty;
            ResponseSave responseSave;

            var wipCheck = await _context.BatteryWIP.Where(a => a.BIN_Number.Equals(batteryDetailsList[0].BIN_Number)).ToListAsync();
            //Console.WriteLine("count " + wipBinList.Count());
            if (wipCheck.Count <= 0)
            {

                responseSave = new ResponseSave("WIP Data Not Present!", 300);

                return responseSave;
            }

                foreach (BatteryDetails batteryDetails in batteryDetailsList)
            {

                //Update PlanID
                //if (!batteryDetails.StationName.Equals("OP-240"))
                //{
                //    try
                //    {

                //        //Save All 3 tables for NG params
                //        var wipBinList = await _context.BatteryWIP.Where(a => a.BIN_Number.Equals(batteryDetails.BIN_Number)).ToListAsync();
                //        Console.WriteLine("count " + wipBinList.Count());
                //        if (wipBinList.Count > 0)
                //        {

                //            //Update batteryWIP
                //            var batteryWIP = await _context.BatteryWIP.Where(a => a.BIN_Number.Equals(batteryDetails.BIN_Number)).ToListAsync();
                //            if (batteryDetails.PlanID.Equals("") || batteryDetails.PlanID.Equals(" "))
                //            {
                //                batteryWIP.ForEach(a => a.PlanID = 0);
                //            }
                //            else
                //            {
                //                batteryWIP.ForEach(a => a.PlanID = Int32.Parse(batteryDetails.PlanID));
                //            }

                //            await _context.SaveChangesAsync();
                //            status = "Success";
                //        }
                //        else
                //        {
                //            status = "Failure";
                //        }



                //    }

                //    catch (DbUpdateException e)
                //    {
                //        status = "Failure";
                //    }

                //}

                try
                {

                    if (!batteryDetails.ParameterId.Equals("D1135") || !batteryDetails.ParameterId.Equals("D1136"))
                    {


                        if (!batteryDetails.ParameterId.Equals("D2001"))
                        {

                            //OK-NOK 
                            if (!batteryDetails.ParameterVal.Equals("2"))
                            {
                                //Save only genealogy for FG params
                                BatteryDetailsGeneology batteryDetailsGeneology = new(Convert.ToDateTime(batteryDetails.Timestamp), batteryDetails.BIN_Number, Int32.Parse(batteryDetails.StationId), batteryDetails.ParameterId, batteryDetails.ParameterVal, batteryDetails.Quality, Int32.Parse(batteryDetails.ParameterVal));
                                _context.BatteryDetailsGeneology.Add(batteryDetailsGeneology);
                                await _context.SaveChangesAsync();
                                status = "Success";

                                var batteryWIP = await _context.BatteryWIP.Where(a => a.BIN_Number.Equals(batteryDetailsList[0].BIN_Number)).ToListAsync();
                                batteryWIP.ForEach(a => a.Status = Int32.Parse(batteryDetailsList[0].Status));
                                if (batteryDetailsList[0].EndTime != null && !batteryDetailsList[0].EndTime.Equals(""))
                                {
                                    batteryWIP.ForEach(a => a.EndTime = Convert.ToDateTime(batteryDetailsList[0].EndTime));

                                }
                                else
                                {
                                    batteryWIP.ForEach(a => a.EndTime = DateTime.Now);

                                }


                            }
                            else
                            {

                                //Save All 3 tables for NG params
                                var wipBinList = await _context.BatteryWIP.Where(a => a.BIN_Number.Equals(batteryDetails.BIN_Number)).ToListAsync();
                                Console.WriteLine("count " + wipBinList.Count());
                                if (wipBinList.Count <= 0)
                                {

                                    responseSave = new ResponseSave("WIP Data Not Present!", 300);

                                    return responseSave;

                                    BatteryDetailsGeneology batteryDetailsGeneology = new(Convert.ToDateTime(batteryDetails.Timestamp), batteryDetails.BIN_Number, Int32.Parse(batteryDetails.StationId), batteryDetails.ParameterId, batteryDetails.ParameterVal, batteryDetails.Quality, Int32.Parse(batteryDetails.ParameterVal));
                                    BatteryDetailsRejection batteryDetailsRejection = new(batteryDetails.ParameterId, batteryDetails.ParameterVal, batteryDetails.BIN_Number, Int32.Parse(batteryDetails.StationId), batteryDetails.Category, batteryDetails.SubCategory, batteryDetails.OperatorRemark, batteryDetails.BUGId, batteryDetails.QIRemarks, batteryDetails.RSARemark, Int32.Parse(batteryDetails.PartChangeFlag), Int32.Parse(batteryDetails.SKUChangeFlag), batteryDetails.ReworkRemark, Int32.Parse(batteryDetails.line));
                                    BatteryWIP batteryWIP = new(batteryDetails.BIN_Number, batteryDetails.line, Convert.ToDateTime(batteryDetails.StartTime), Convert.ToDateTime(batteryDetails.EndTime), int.Parse(batteryDetails.StationId), int.Parse(batteryDetails.Status), 0, batteryDetails.StationName);

                                    //genealogy
                                    _context.BatteryDetailsGeneology.Add(batteryDetailsGeneology);
                                    await _context.SaveChangesAsync();
                                    Console.WriteLine(batteryWIP);

                                    {
                                        //rejecction
                                        _context.BatteryDetailsRejection.Add(batteryDetailsRejection);
                                        await _context.SaveChangesAsync();
                                        status = "Success";
                                        Console.WriteLine(status);
                                    }

                                    {
                                        //Insert batteryWIP
                                        _context.BatteryWIP.Add(batteryWIP);
                                        await _context.SaveChangesAsync();
                                        status = "Success";
                                        Console.WriteLine(status);
                                    }
                                }
                                else
                                {


                                    BatteryDetailsGeneology batteryDetailsGeneology = new(Convert.ToDateTime(batteryDetails.Timestamp), batteryDetails.BIN_Number, Int32.Parse(batteryDetails.StationId), batteryDetails.ParameterId, batteryDetails.ParameterVal, batteryDetails.Quality, Int32.Parse(batteryDetails.ParameterVal));
                                    BatteryDetailsRejection batteryDetailsRejection = new(batteryDetails.ParameterId, batteryDetails.ParameterVal, batteryDetails.BIN_Number, Int32.Parse(batteryDetails.StationId), batteryDetails.Category, batteryDetails.SubCategory, batteryDetails.OperatorRemark, batteryDetails.BUGId, batteryDetails.QIRemarks, batteryDetails.RSARemark, Int32.Parse(batteryDetails.PartChangeFlag), Int32.Parse(batteryDetails.SKUChangeFlag), batteryDetails.ReworkRemark, Int32.Parse(batteryDetails.line));

                                    _context.BatteryDetailsGeneology.Add(batteryDetailsGeneology);
                                    await _context.SaveChangesAsync();

                                    {
                                        _context.BatteryDetailsRejection.Add(batteryDetailsRejection);
                                        await _context.SaveChangesAsync();
                                        status = "Success";
                                    }

                                    {
                                        //Update batteryWIP
                                        var batteryWIP = await _context.BatteryWIP.Where(a => a.BIN_Number.Equals(batteryDetails.BIN_Number)).ToListAsync();
                                        batteryWIP.ForEach(a => a.Status = Int32.Parse(batteryDetails.Status));
                                        batteryWIP.ForEach(a => a.StationName = batteryDetails.StationName);
                                        //            batteryWIP.ForEach(a => a.ReEntryStation = Int32.Parse(batteryDetails.StationId));

                                        await _context.SaveChangesAsync();
                                        status = "Success";
                                    }
                                }


                            }
                        }
                        else
                        //D2001 parameter
                        {
                            if (batteryDetails.ParameterVal.Equals("4") || batteryDetails.ParameterVal.Equals("5") || batteryDetails.ParameterVal.Equals("6"))
                            {
                                BatteryDetailsGeneology batteryDetailsGeneology = new(Convert.ToDateTime(batteryDetails.Timestamp), batteryDetails.BIN_Number, Int32.Parse(batteryDetails.StationId), batteryDetails.ParameterId, batteryDetails.ParameterVal, batteryDetails.Quality, 2);
                                _context.BatteryDetailsGeneology.Add(batteryDetailsGeneology);
                                await _context.SaveChangesAsync();
                                status = "Success";
                            }
                            else
                            {
                                BatteryDetailsGeneology batteryDetailsGeneology = new(Convert.ToDateTime(batteryDetails.Timestamp), batteryDetails.BIN_Number, Int32.Parse(batteryDetails.StationId), batteryDetails.ParameterId, batteryDetails.ParameterVal, batteryDetails.Quality, 1);
                                _context.BatteryDetailsGeneology.Add(batteryDetailsGeneology);
                                await _context.SaveChangesAsync();
                                status = "Success";
                            }


                        }
                    }
                }

                catch (DbUpdateException e)
                {
                    status = "Failure";
                }

            }

            if (status == "Success" && batteryDetailsList[0].Status == "9")
            {
                //Update batteryWIP
                var batteryWIP = await _context.BatteryWIP.Where(a => a.BIN_Number.Equals(batteryDetailsList[0].BIN_Number)).ToListAsync();
                batteryWIP.ForEach(a => a.Status = Int32.Parse(batteryDetailsList[0].Status));
                batteryWIP.ForEach(a => a.StationName = batteryDetailsList[0].StationName);

                await _context.SaveChangesAsync();
                status = "Success";
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

        [HttpPost("saveplanidcommon")]
        public async Task<ResponseSave> SavePlanIdCommon(List<BatteryDetails> batteryDetailsList)
        {
            string status = string.Empty;
            ResponseSave responseSave;


            foreach (BatteryDetails batteryDetails in batteryDetailsList)
            {

                try
                {

                    if (!batteryDetails.ParameterId.Equals("D2001"))
                    {


                        Quality_DHCRejection_WIPCommon batteryDetailsRejection = new(batteryDetails.ParameterId, batteryDetails.ParameterVal, batteryDetails.BIN_Number, Int32.Parse(batteryDetails.StationId), batteryDetails.Category, batteryDetails.SubCategory, batteryDetails.OperatorRemark, batteryDetails.BUGId, batteryDetails.QIRemarks, batteryDetails.RSARemark, Int32.Parse(batteryDetails.PartChangeFlag), Int32.Parse(batteryDetails.SKUChangeFlag), batteryDetails.ReworkRemark, Int32.Parse(batteryDetails.line), Int32.Parse(batteryDetails.Status), batteryDetails.ReworkStationName, Int32.Parse(batteryDetails.SaveFlag));

                        {
                            //rejecction
                            _context.Quality_DHCRejection_WIPCommon.Add(batteryDetailsRejection);
                            await _context.SaveChangesAsync();
                            status = "Success";
                            Console.WriteLine(status);
                        }

                    }

                }

                catch (DbUpdateException e)
                {
                    status = "Failure";
                }

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

        [HttpPost("reworkgenealogy")]
        public async Task<ResponseSave> SaveReworkGenealogy(Prod_ReworkGeneology prods)
        {
            string status = string.Empty;
            ResponseSave responseSave;



            try
            {
                DateTime d = DateTime.Now;
                prods.Timestamp = d;

                if (!prods.ParameterId.Equals("D2001"))
                {
                    //rejecction
                    _context.Prod_ReworkGeneology.Add(prods);
                    await _context.SaveChangesAsync();
                    status = "Success";
                    Console.WriteLine(status);
                }

            }

            catch (DbUpdateException e)
            {
                status = "Failure";
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


        [HttpPost("statusgenealogy")]
        public async Task<ResponseSave> SaveStatusGenealogy(StatusGenealogy statusGenealogy)
        {

            ResponseSave responseSave;

            try
            {
                if (statusGenealogy != null)
                {
                    if (statusGenealogy.BIN_Number != null && !statusGenealogy.BIN_Number.Equals(""))
                    {
                        var mes_production_plan_sku = MES_PRODUCTION_PLAN_SKU(statusGenealogy.BIN_Number).Result;

                        if (mes_production_plan_sku != null && !mes_production_plan_sku.Equals(""))
                        {
                            StatusGenealogy statsus = new StatusGenealogy(Convert.ToDateTime(statusGenealogy.Proddate), statusGenealogy.ProdShift, DateTime.Now, statusGenealogy.BIN_Number, mes_production_plan_sku, statusGenealogy.StationId, statusGenealogy.Status);
                            _context.StatusGenealogy.Add(statsus);
                            await _context.SaveChangesAsync();
                            responseSave = new ResponseSave("Data saved successfully!", 200);
                        }
                        else
                        {
                            responseSave = new ResponseSave("Data not saved !", 300);
                        }
                    }

                    else
                    {
                        responseSave = new ResponseSave("Data not saved !", 300);
                    }
                }
                else
                {
                    responseSave = new ResponseSave("Data not saved !", 300);
                }
            }
            catch (DbUpdateException e)
            {
                responseSave = new ResponseSave("Data not saved !" + e, 300);
            }






            return responseSave;
        }
        private async Task<string> MES_PRODUCTION_PLAN_SKU(string binnumber)
        {
            var sku = await _context.Prod_MESProductionPlan.Where(a => a.BIN_Number.Equals(binnumber)).FirstOrDefaultAsync();

            return sku.SKUId;
        }

    }
}