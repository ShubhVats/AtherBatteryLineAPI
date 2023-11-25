using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AtherMesRestApi.MESModels;
using AtherMesRestApi.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AtherMesRestApi.Controllers
{
    [Route("api")]
    [ApiController]

    public class UpdateBatteryController : ControllerBase
    {
        private readonly MESDBContext _context;


        public UpdateBatteryController(MESDBContext context)
        {
            _context = context;
        }
        public List<BinList> BinLists { get; private set; }

        [HttpPost("operatorUpdate")]
        public async Task<ResponseSave> UpdateBinDetails(List<BatteryDetails> batteryDetailsList)
        {
            string status = "Failure";
            ResponseSave responseSave;
            List<string> StationName4SPR = new List<string>();
            List<string> prevStationID = new List<string>();

            foreach (BatteryDetails batteryDetails in batteryDetailsList)
            {

                try
                {
                    if (batteryDetails.ParameterId.Equals("D2001"))
                    {

                        //D2001 parameter
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
                    else
                    {
                        if (batteryDetails.SaveFlag == "1")
                        {
                            //Update batteryWIP
                            var batteryWIP = await _context.BatteryWIP.Where(a => a.BIN_Number.Equals(batteryDetails.BIN_Number)).ToListAsync();
                            batteryWIP.ForEach(a => a.Status = Int32.Parse(batteryDetails.Status));
                            batteryWIP.ForEach(a => a.EndTime = DateTime.Now);
                            batteryWIP.ForEach(a => a.ReEntryStation = Int32.Parse(batteryDetails.ReEntryStation));
                            batteryWIP.ForEach(a => a.SaveFlag = Int32.Parse(batteryDetails.SaveFlag));


                            await _context.SaveChangesAsync();
                            status = "Success";

                            {
                                //Update RejectionTable
                                var batteryDetailsRejection = await _context.BatteryDetailsRejection.Where(a => a.BIN_Number.Equals(batteryDetails.BIN_Number) && a.ParameterId.Equals(batteryDetails.ParameterId)).ToListAsync();
                                batteryDetailsRejection.ForEach(a => a.PartChangeFlag = Int32.Parse(batteryDetails.PartChangeFlag));
                                batteryDetailsRejection.ForEach(a => a.SKUChangeFlag = Int32.Parse(batteryDetails.SKUChangeFlag));
                                batteryDetailsRejection.ForEach(a => a.ReworkRemark = batteryDetails.ReworkRemark);
                                if (batteryDetails.BUGId != null)
                                {
                                    batteryDetailsRejection.ForEach(a => a.BUGId = batteryDetails.BUGId);
                                }
                                await _context.SaveChangesAsync();
                            }


                        }
                        else
                        {

                            //Insert into Geneology
                            BatteryDetailsGeneology batteryDetailsGeneology = new(Convert.ToDateTime(batteryDetails.Timestamp), batteryDetails.BIN_Number, Int32.Parse(batteryDetails.StationId), batteryDetails.ParameterId, batteryDetails.ParameterVal, batteryDetails.Quality, Int32.Parse(batteryDetails.ParameterVal));
                            _context.BatteryDetailsGeneology.Add(batteryDetailsGeneology);
                            await _context.SaveChangesAsync();
                            status = "Success";


                            //Update RejectionWIP
                            var batteryDetailsRejection = _context.BatteryDetailsRejection.Where(a => a.BIN_Number.Equals(batteryDetails.BIN_Number) && a.ParameterId.Equals(batteryDetails.ParameterId)).ToList();
                            batteryDetailsRejection.ForEach(a => a.ParameterVal = batteryDetails.ParameterVal);
                            batteryDetailsRejection.ForEach(a => a.OperatorRemark = batteryDetails.OperatorRemark);
                            batteryDetailsRejection.ForEach(a => a.Category = batteryDetails.Category);
                            batteryDetailsRejection.ForEach(a => a.SubCategory = batteryDetails.SubCategory);
                            batteryDetailsRejection.ForEach(a => a.BUGId = batteryDetails.BUGId);
                            batteryDetailsRejection.ForEach(a => a.QIRemarks = batteryDetails.QIRemarks);
                            batteryDetailsRejection.ForEach(a => a.RSARemark = batteryDetails.RSARemark);
                            batteryDetailsRejection.ForEach(a => a.PartChangeFlag = Int32.Parse(batteryDetails.PartChangeFlag));
                            batteryDetailsRejection.ForEach(a => a.SKUChangeFlag = Int32.Parse(batteryDetails.SKUChangeFlag));
                            batteryDetailsRejection.ForEach(a => a.ReworkRemark = batteryDetails.ReworkRemark);
                            batteryDetailsRejection.ForEach(a => a.LineId = Int32.Parse(batteryDetails.line));
                            await _context.SaveChangesAsync();

                            //Update batteryWIP
                            var batteryWIP = _context.BatteryWIP.Where(a => a.BIN_Number.Equals(batteryDetails.BIN_Number)).ToList();
                            batteryWIP.ForEach(a => a.Status = Int32.Parse(batteryDetails.Status));
                            batteryWIP.ForEach(a => a.EndTime = DateTime.Now);
                            batteryWIP.ForEach(a => a.ReEntryStation = Int32.Parse(batteryDetails.ReEntryStation));
                            await _context.SaveChangesAsync();
                            status = "Success";

                            //Update count in SPR Table
                            if (batteryDetails.Status == "5")
                            {

                                if (!StationName4SPR.Contains(batteryDetails.StationName))
                                {
                                    try
                                    {

                                        StationName4SPR.Add(batteryDetails.StationName);
                                        var spr = await _context.Pref_SPRLoss.Where(a => a.StationName.Equals(batteryDetails.StationName)).ToListAsync();
                                        spr.ForEach(a => ++a.SPRcount);
                                        spr.ForEach(a => a.Timestamp = Convert.ToDateTime(batteryDetails.Timestamp));
                                        await _context.SaveChangesAsync();
                                        status = "Success";
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine("Error " + e);
                                    }
                                }
                            }
                            //Rework Okay update station genealogy
                            else if (batteryDetails.Status == "7")
                            {
                                if (!prevStationID.Contains(batteryDetails.StationId))
                                {
                                    prevStationID.Add(batteryDetails.StationId);

                                    string parameterID = "";
                                    if (batteryDetails.StationId.Length > 1)
                                    {
                                        parameterID = "D0" + batteryDetails.StationId;
                                    }
                                    else
                                    {
                                        parameterID = "D00" + batteryDetails.StationId;


                                    }
                                    Prod_StationGeneology stationGeneology;


                                    stationGeneology = new(Convert.ToDateTime(batteryDetails.Timestamp), batteryDetails.BIN_Number, Int32.Parse(batteryDetails.StationId), parameterID, batteryDetails.ParameterVal, batteryDetails.Quality, 1);

                                    try
                                    {
                                        _context.Prod_StationGeneology.Add(stationGeneology);
                                        await _context.SaveChangesAsync();
                                        status = "Success";

                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e);
                                        status = "Failed";

                                    }
                                }
                            }
                        }

                    }


                }

                catch (DbUpdateException e)
                {
                    status = "Failure";
                    Console.WriteLine("Error: " + e.Message);
                    //Console.WriteLine("Here12");
                }

            }

            if (status == "Success")
            {
                if (batteryDetailsList[0].Status == "7")
                {
                    try
                    {

                        //Insert into Geneology
                        BatteryDetailsGeneology batteryDetailsGeneology = new(Convert.ToDateTime(batteryDetailsList[0].Timestamp), batteryDetailsList[0].BIN_Number, Int32.Parse(batteryDetailsList[0].StationId), batteryDetailsList[0].ParameterId, batteryDetailsList[0].ParameterVal, batteryDetailsList[0].Quality, Int32.Parse(batteryDetailsList[0].ParameterVal));
                        _context.BatteryDetailsGeneology.Add(batteryDetailsGeneology);
                        await _context.SaveChangesAsync();
                        status = "Success";
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error " + e);
                        status = "Error";
                    }
                }
            }

            if (status == "Success")
            {
                responseSave = new ResponseSave("Data updated successfully!", 200);
            }
            else
            {
                responseSave = new ResponseSave("Data not updated.", 300);
            }

            return responseSave;
        }

        [HttpGet("battery/{number}/{line}")]
        public async Task<ActionResult<ResponseBatteryWIP>> GetStatusWiseBinList(string number, string line)
        {
            ResponseBatteryWIP responseBinList;


            List<BatteryWIP> BinLists = await _context.BatteryWIP.Where(a => a.BIN_Number.Equals(number))
                 .ToListAsync();

            var mes_production_plan_sku = MES_PRODUCTION_PLAN_SKU(number).Result;
            BinLists.ForEach(a => a.SKUId = mes_production_plan_sku);

            if (BinLists == null)
            {
                responseBinList = new ResponseBatteryWIP("data not found", 300, null);
                //return NotFound();
            }
            else
            {
                if (BinLists.Count > 0)
                {
                    responseBinList = new ResponseBatteryWIP("data found", 200, BinLists);

                }
                else
                {
                    responseBinList = new ResponseBatteryWIP("data not found", 300, null);
                }
            }

            return responseBinList;
        }

        [HttpPost("operatorUpdateCommon")]
        public async Task<ResponseSave> UpdateBinDetailsCommon(List<BatteryDetails> batteryDetailsList)
        {
            string status = "Failure";
            ResponseSave responseSave;
            int closeFlag = 0, updateFlag = 0;
            //List<string> StationName4SPR = new List<string>();


            //Get all bug data
            var tickets = _context.JIRA_Send_Data.Where(a => a.BIN_Number.Equals(batteryDetailsList[0].BIN_Number) && a.Ticket_Number != null).ToList();


            try
            {

                foreach (BatteryDetails batteryDetails in batteryDetailsList)
                {

                    //Update RejectionTable
                    var batteryDetailsRejection = await _context.Quality_DHCRejection_WIPCommon.Where(a => a.BIN_Number.Equals(batteryDetails.BIN_Number) && a.Status!=2 && a.Status != 7 && (a.ParameterId.Equals(batteryDetails.ParameterId) || a.ParameterId.Equals("D1135") || a.ParameterId.Equals("D1136"))).ToListAsync();
                    batteryDetailsRejection.ForEach(a => a.ParameterVal = batteryDetails.ParameterVal);
                    batteryDetailsRejection.ForEach(a => a.OperatorRemark = batteryDetails.OperatorRemark);
                    batteryDetailsRejection.ForEach(a => a.Category = batteryDetails.Category);
                    batteryDetailsRejection.ForEach(a => a.SubCategory = batteryDetails.SubCategory);
                    batteryDetailsRejection.ForEach(a => a.BUGId = batteryDetails.BUGId);
                    batteryDetailsRejection.ForEach(a => a.QIRemarks = batteryDetails.QIRemarks);
                    batteryDetailsRejection.ForEach(a => a.RSARemark = batteryDetails.RSARemark);
                    batteryDetailsRejection.ForEach(a => a.PartChangeFlag = Int32.Parse(batteryDetails.PartChangeFlag));
                    batteryDetailsRejection.ForEach(a => a.SKUChangeFlag = Int32.Parse(batteryDetails.SKUChangeFlag));
                    batteryDetailsRejection.ForEach(a => a.ReworkRemark = batteryDetails.ReworkRemark);
                    batteryDetailsRejection.ForEach(a => a.Status = Int32.Parse(batteryDetails.Status));
                    batteryDetailsRejection.ForEach(a => a.SaveFlag = Int32.Parse(batteryDetails.SaveFlag));


                    //Save Single parameter to server
                    await _context.SaveChangesAsync();
                    status = "Success";


                    //JIRA CLOSE TICKET AND UPDATE BUGID
                    if (batteryDetails.Status == "4" || batteryDetails.Status == "5" || batteryDetails.Status == "6" || batteryDetails.Status == "7")
                    {

                        UPDATE_JIRA_BUGID(batteryDetails, tickets);
                    }

                    //if (closeFlag == 0 && batteryDetails.Status == "8")
                    //{

                    //    CLOSE_JIRA_TICKETS(batteryDetails, tickets);

                    //    closeFlag++;

                    //}
                }

                if (batteryDetailsList[0].BIN_Number != null)
                {
                    if (batteryDetailsList[0].Status == "7")
                    {
                        await postImage2JIRAaaa(batteryDetailsList[0].BIN_Number);
                    }
                }
            }

            catch (DbUpdateException e)
            {
                status = "Failure";
                Console.WriteLine("Error: " + e.Message);
            }


            if (status == "Success")
            {
                responseSave = new ResponseSave("Data updated successfully!", 200);
            }
            else
            {
                responseSave = new ResponseSave("Data not updated.", 300);
            }

            return responseSave;
        }

        [HttpGet("jiraclose/{binnumber}")]
        public async Task<ResponseSave> closeJiraCommon(string binnumber)
        {
            string status = "Failure";
            ResponseSave responseSave;
            int closeFlag = 0, updateFlag = 0;
            //List<string> StationName4SPR = new List<string>();


            //Get all bug data
            var tickets = _context.JIRA_Send_Data.Where(a => a.BIN_Number.Equals(binnumber) && a.Ticket_Number != null).ToList();

            try
            {
                if (closeFlag == 0)
                {

                    CLOSE_JIRA_TICKETS(tickets);

                    closeFlag++;
                    status = "Success";

                }
            }

            catch (DbUpdateException e)
            {
                status = "Failure";
                Console.WriteLine("Error: " + e.Message);
            }


            if (status == "Success")
            {
                responseSave = new ResponseSave("Data updated successfully!", 200);
            }
            else
            {
                responseSave = new ResponseSave("Data not updated.", 300);
            }

            return responseSave;
        }


        private void UPDATE_JIRA_BUGID(BatteryDetails batteryDetails, List<JIRA_Send_Data> tickets)
        {
            Boolean resStatus = true;

            //var tickets = _context.JIRA_Send_Data.Where(a => a.BIN_Number.Equals(batteryDetails.BIN_Number) && a.Parameter_Name.Equals(batteryDetails.ParameterId) && a.Inserted_By.Equals("Quality") && a.Ticket_Number != null).ToList();

            foreach (JIRA_Send_Data ticket in tickets)
            {
                if (ticket.Parameter_Name.Equals(batteryDetails.ParameterId) && ticket.Inserted_By.Equals("Quality"))
                {

                    var client = new HttpClient();
                    var request = new HttpRequestMessage(HttpMethod.Put, "https://jira.atherengineering.in/rest/api/2/issue/" + ticket.Ticket_Number);
                    request.Headers.Add("Authorization", "Basic SmlyYUF1dG9tYXRpb24wMTp1eFRsdFZ3cnhycU1GOExWVXJXYw==");
                    var content = new StringContent("{\"fields\":{\"customfield_24312\":{\"key\":\"" + batteryDetails.BUGId + "\"},\"customfield_23330\":\"" + batteryDetails.ReworkRemark + "\"}}", null, "application/json"); request.Content = content;
                    var response = client.Send(request);
                    response.EnsureSuccessStatusCode();
                    //Console.WriteLine(await response.Content.ReadAsStringAsync());
                    if (!response.IsSuccessStatusCode)
                    {
                        //imageSendStatus = false; //To be uncommented when NULL is removed from ticketNumber Entry
                    }
                }
            }
        }
        private void CLOSE_JIRA_TICKETS(List<JIRA_Send_Data> tickets)
        {
            //var tickets = _context.JIRA_Send_Data.Where(a => a.BIN_Number.Equals(batteryDetails.BIN_Number) && a.Ticket_Number != null).ToList();

            Boolean resStatus = true;

            foreach (JIRA_Send_Data ticket in tickets)
            {
                if (ticket.Ticket_Number != null)
                {
                    //Thread.Sleep(5000);//sleep for 5 seconds
                    var client = new HttpClient();
                    var request = new HttpRequestMessage(HttpMethod.Post, "https://jira.atherengineering.in/rest/api/2/issue/" + ticket.Ticket_Number + "/transitions");
                    request.Headers.Add("Authorization", "Basic SmlyYUF1dG9tYXRpb24wMTp1eFRsdFZ3cnhycU1GOExWVXJXYw==");
                    var content = new StringContent("{\"transition\":{\"id\":\"11\"}}", null, "application/json"); request.Content = content;
                    var response = client.Send(request);
                    //response.EnsureSuccessStatusCode();
                    Console.WriteLine(response.Content.ReadAsStringAsync());

                    //if (!response.IsSuccessStatusCode)
                    //{
                    //    //imageSendStatus = false; //To be uncommented when NULL is removed from ticketNumber Entry
                    //}
                }
            }

        }
        private async Task<string> MES_PRODUCTION_PLAN_SKU(string binnumber)
        {
            var sku = await _context.Prod_MESProductionPlan.Where(a => a.BIN_Number.Equals(binnumber)).FirstOrDefaultAsync();

            return sku.SKUId;
        }
        private async Task<string> postImage2JIRAaaa(string binnum)
        {

            try
            {

                var ImagesList = await _context.Quality_DHCImage.Where(a => a.BIN_Number.Equals(binnum) && a.IsDelete.Equals(false)).ToListAsync();
                var issues = await _context.JIRA_Send_Data.Where(a => a.BIN_Number.Equals(binnum) && a.Ticket_Number != null).ToListAsync();
                Boolean imageSendStatus = true;

                List<ByteArrayContent> filecontentList = new List<ByteArrayContent>();
                List<string> filecontentNameList = new List<string>();
                byte[] result;

                foreach (Quality_DHCImage imgList in ImagesList)
                {
                    if (imgList != null)
                    {

                        var imgPath = imgList.ImagePath;
                        imgPath = imgPath.Substring(28, 13);

                        filecontentNameList.Add(imgPath);

                        //var bytess = await System.IO.File.ReadAllBytesAsync(@"Y:\\Applications\\QIImage-New\\" + imgPath + ".png");

                        using (FileStream stream = System.IO.File.OpenRead((@"C:\\Applications\\QIImage-New\\" + imgPath + ".png")))
                        {
                            result = new byte[stream.Length];
                            await stream.ReadAsync(result, 0, (int)stream.Length);
                        }


                        using var fileContents = new ByteArrayContent(result);


                        foreach (JIRA_Send_Data issue in issues)
                        {
                            var client = new HttpClient();
                            var request = new HttpRequestMessage(HttpMethod.Post, "https://jira.atherengineering.in/rest/api/2/issue/" + issue.Ticket_Number + "/attachments");
                            request.Headers.Add("X-Atlassian-Token", "no-check");
                            request.Headers.Add("Authorization", "Basic SmlyYUF1dG9tYXRpb24wMTp1eFRsdFZ3cnhycU1GOExWVXJXYw==");
                            var content = new MultipartFormDataContent();

                            //for (int i = 0; i < filecontentList.Count; i++)
                            //{
                            Console.WriteLine(fileContents.ReadAsStringAsync().ToString());
                            content.Add(fileContents, "file", imgPath + ".png");
                            //}

                            request.Content = content;
                            var response = await client.SendAsync(request);
                            var res = await response.Content.ReadAsStringAsync();

                        }


                        //Console.WriteLine(filecontentList[0].ReadAsStringAsync().ToString());

                    }
                }

                ImagesList.ForEach(a => a.IsDelete = true);
                await _context.SaveChangesAsync();

                return "Success";
            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now + " Api Operations exception: " + ", " + ex.ToString());

                return ex.ToString();

            }
        }

    }
}