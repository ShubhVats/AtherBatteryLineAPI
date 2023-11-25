using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AtherMesRestApi.MESModels;
using AtherMesRestApi.ResponseModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace AtherMesRestApi.Controllers
{
    [Route("api/JIRA")]
    [ApiController]
    public class JIRAController : Controller
    {

        private String baseUrl;
        private string userId;
        private string password;
        private string base64AuthString;

        private readonly MESDBContext _context;
        public static IWebHostEnvironment _environment;

        public JIRAController(IWebHostEnvironment environment, MESDBContext context)
        {
            _environment = environment;
            _context = context;
        }

        //GET: api/SapOrders/5

        [HttpGet("getbuglist")]
            public List<ReponseJIRASearchSQL> getBugList()
            {
                var baseUrl = "https://jira.atherengineering.in/rest/api/2/";

                userId = "JiraAutomation01";
                password = "uxTltVwrxrqMF8LVUrWc";

                string useridPwd = userId + ":" + password;
                Console.WriteLine(useridPwd);
                byte[] useridPwd_byt = System.Text.Encoding.UTF8.GetBytes(useridPwd);
                base64AuthString = Convert.ToBase64String(useridPwd_byt);

                string endpoint = baseUrl + "search";
                string method = "POST";

                List<string> fields = new List<string>() { "summary", "key" };
                JiraSearch jira = new JiraSearch("issuetype = Bug and project = Gen2 order by Created desc", 0, 50, fields);

                string json = JsonConvert.SerializeObject(jira);

                WebClient wc = new WebClient();
                //string idpwb64 = "NUNfQ09NUDpBUEkjMTIzNA==";

                wc.Headers["Content-Type"] = "application/json";
                wc.Headers["Authorization"] = "Basic " + base64AuthString;
                try
                {
                    var responseAPI = wc.UploadString(endpoint, method, json);

                    Console.WriteLine("response:" + responseAPI);

                    ResponseJiraSearch _response = JsonConvert.DeserializeObject<ResponseJiraSearch>(responseAPI);

                    List<ReponseJIRASearchSQL> listSqlResponse = new List<ReponseJIRASearchSQL>();

                    for (int i = 0; i < _response.issues.Count; i++)
                    {
                    //add only when not already availabe in the DB
                    if (checkIfNotAvailabe(_response.issues[i].id))
                    {
                        ReponseJIRASearchSQL sqlResponse = new ReponseJIRASearchSQL(_response.issues[i].id, _response.issues[i].key, _response.issues[i].fields.summary);
                        listSqlResponse.Add(sqlResponse);

                    }
                }

                    //return JsonConvert.DeserializeObject<SPResponse_DOWN>(response);
                    return listSqlResponse;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(DateTime.Now + " Api Operations exception: " + ", " + ex.ToString());

                    return null;
                }
            }

        private bool checkIfNotAvailabe(string id)
        {
            return _context.BugListConfig.Any(e => e.Bug_ID == Int64.Parse(id));
        }

        [HttpPost("binCreation")]
        public string postTicket(TicketCreate ticket)
        {
            var baseUrl = "https://jira.atherengineering.in/rest/api/2/";

            userId = "JiraAutomation01";
            password = "uxTltVwrxrqMF8LVUrWc";

            string useridPwd = userId + ":" + password;
            Console.WriteLine(useridPwd);
            byte[] useridPwd_byt = System.Text.Encoding.UTF8.GetBytes(useridPwd);
            base64AuthString = Convert.ToBase64String(useridPwd_byt);

            string endpoint = baseUrl + "issue/";
            string method = "POST";

            string json = JsonConvert.SerializeObject(ticket);

            WebClient wc = new WebClient();
            //string idpwb64 = "NUNfQ09NUDpBUEkjMTIzNA==";

            wc.Headers["Content-Type"] = "application/json";
            wc.Headers["Authorization"] = "Basic " + base64AuthString;
            try
            {
                Console.WriteLine(endpoint);
                Console.WriteLine(method);
                Console.WriteLine(json);
                var responseAPI = wc.UploadString(endpoint, method, json);

                Console.WriteLine("response:" + responseAPI);

                //                ResponseJiraSearch _response = JsonConvert.DeserializeObject<ResponseJiraSearch>(responseAPI);

                //return JsonConvert.DeserializeObject<SPResponse_DOWN>(response);
                return responseAPI;
            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now + " Api Operations exception: " + ", " + ex.ToString());

                return "Error: " + ex;
            }
        }

        [HttpPost("binIssueCreate")]
        public string createBinIssue(issueCreation ticket)
        {
            var baseUrl = "https://jira.atherengineering.in/rest/api/2/";

            userId = "JiraAutomation01";
            password = "uxTltVwrxrqMF8LVUrWc";

            string useridPwd = userId + ":" + password;
            Console.WriteLine(useridPwd);
            byte[] useridPwd_byt = System.Text.Encoding.UTF8.GetBytes(useridPwd);
            base64AuthString = Convert.ToBase64String(useridPwd_byt);

            string endpoint = baseUrl + "issue/";
            string method = "POST";

            string json = JsonConvert.SerializeObject(ticket);

            WebClient wc = new WebClient();
            //string idpwb64 = "NUNfQ09NUDpBUEkjMTIzNA==";

            wc.Headers["Content-Type"] = "application/json";
            wc.Headers["Authorization"] = "Basic " + base64AuthString;
            try
            {
                var responseAPI = wc.UploadString(endpoint, method, json);

                Console.WriteLine("response:" + responseAPI);

                //     ResponseJiraSearch _response = JsonConvert.DeserializeObject<ResponseJiraSearch>(responseAPI);

                //return JsonConvert.DeserializeObject<SPResponse_DOWN>(response);
                return responseAPI;
            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now + " Api Operations exception: " + ", " + ex.ToString());

                return "Error: " + ex;
            }
        }

        [HttpPost("binIssueUpdate")]
        public string updateBinIssue(issueUpdate ticket)
        {
            var baseUrl = "https://jira.atherengineering.in/rest/api/2/issue/";

            userId = "JiraAutomation01";
            password = "uxTltVwrxrqMF8LVUrWc";

            string useridPwd = userId + ":" + password;
            Console.WriteLine(useridPwd);
            byte[] useridPwd_byt = System.Text.Encoding.UTF8.GetBytes(useridPwd);
            base64AuthString = Convert.ToBase64String(useridPwd_byt);

            string endpoint = baseUrl + ticket.Id;
            string method = "PUT";

            JiraIssueUpdateInternal jiraIssue = new JiraIssueUpdateInternal()
            {
                fields = ticket.fields
            };

            WebClient wc = new WebClient();
            //string idpwb64 = "NUNfQ09NUDpBUEkjMTIzNA==";

            string json = JsonConvert.SerializeObject(jiraIssue);

            wc.Headers["Content-Type"] = "application/json";
            wc.Headers["Authorization"] = "Basic " + base64AuthString;
            try
            {
                Console.WriteLine(endpoint);
                Console.WriteLine(method);
                Console.WriteLine(json);
                var responseAPI = wc.UploadString(endpoint, method, json);

                Console.WriteLine("response:" + responseAPI);

                // ResponseJiraSearch _response = JsonConvert.DeserializeObject<ResponseJiraSearch>(responseAPI);

                //return JsonConvert.DeserializeObject<SPResponse_DOWN>(response);
                return responseAPI;
            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now + " Api Operations exception: " + ", " + ex.ToString());

                return "Error: " + ex;
            }
        }

        [HttpPost("vinCreation")]
        public string postVinTicket(VinCreate ticket)
        {
            var baseUrl = "https://jira.atherengineering.in/rest/api/2/";

            userId = "JiraAutomation01";
            password = "uxTltVwrxrqMF8LVUrWc";

            string useridPwd = userId + ":" + password;
            Console.WriteLine(useridPwd);
            byte[] useridPwd_byt = System.Text.Encoding.UTF8.GetBytes(useridPwd);
            base64AuthString = Convert.ToBase64String(useridPwd_byt);

            string endpoint = baseUrl + "issue/";
            string method = "POST";

            string json = JsonConvert.SerializeObject(ticket);

            WebClient wc = new WebClient();
            //string idpwb64 = "NUNfQ09NUDpBUEkjMTIzNA==";

            wc.Headers["Content-Type"] = "application/json";
            wc.Headers["Authorization"] = "Basic " + base64AuthString;
            try
            {
                var responseAPI = wc.UploadString(endpoint, method, json);

                Console.WriteLine("response:" + responseAPI);

                //ResponseJiraSearch _response = JsonConvert.DeserializeObject<ResponseJiraSearch>(responseAPI);

                //return JsonConvert.DeserializeObject<SPResponse_DOWN>(response);
                return responseAPI;
            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now + " Api Operations exception: " + ", " + ex.ToString());

                return "Error: " + ex;
            }
        }

        [HttpPost("saveRemark")]
        public async Task<ResponseSave> postsaveRemark(List<JiraSendDataInput> jiraSendDataInputs)
        {
            string status = "Failed";
            ResponseSave responseSave;

            foreach (JiraSendDataInput batteryDetails in jiraSendDataInputs)
            {
                try
                {

                    if (!batteryDetails.Parameter_Name.Equals("D2001"))
                    {
                        var spr = await _context.JIRA_Send_Data.Where(a => a.BIN_Number.Equals(batteryDetails.BIN_Number) && a.Parameter_Name.Equals(batteryDetails.Parameter_Name)).ToListAsync();

                        //if (spr.Count() <= 0)
                        //{
                        JIRA_Send_Data item = new(Convert.ToDateTime(batteryDetails.Timestamp), batteryDetails.ProdShift, batteryDetails.Inserted_By, batteryDetails.BIN_Number, batteryDetails.LineName, batteryDetails.StationName, batteryDetails.Parameter_Value, batteryDetails.Parameter_Name, batteryDetails.CategoryName, batteryDetails.SubCategoryName, batteryDetails.Rework_Remark, batteryDetails.RSA_Remark, batteryDetails.OperatorRemark, batteryDetails.Bugid, batteryDetails.QIRemark, int.Parse(batteryDetails.Status), batteryDetails.IssueLogCreateRes, batteryDetails.IssueLogUpdateRes);
                        _context.JIRA_Send_Data.Add(item);
                        await _context.SaveChangesAsync();
                        status = "Success";
                    }
                    //else
                    //{

                    //    spr.ForEach(a => a.Timestamp = Convert.ToDateTime(batteryDetails.Timestamp));
                    //    //spr.ForEach(a => a.BIN_Number = batteryDetails.BIN_Number);
                    //    //spr.ForEach(a => a.LineName = batteryDetails.LineName);
                    //    spr.ForEach(a => a.ProdShift = batteryDetails.ProdShift);
                    //    spr.ForEach(a => a.Parameter_Value = batteryDetails.Parameter_Value);
                    //    spr.ForEach(a => a.Parameter_Name = batteryDetails.Parameter_Name);
                    //    spr.ForEach(a => a.CategoryName = batteryDetails.CategoryName);
                    //    spr.ForEach(a => a.SubCategoryName = batteryDetails.SubCategoryName);
                    //    spr.ForEach(a => a.Rework_Remark = batteryDetails.Rework_Remark);
                    //    spr.ForEach(a => a.RSA_Remark = batteryDetails.RSA_Remark);
                    //    spr.ForEach(a => a.OperatorRemark = batteryDetails.OperatorRemark);
                    //    //spr.ForEach(a => a.Bugid = batteryDetails.Bugid);
                    //    spr.ForEach(a => a.QIRemark = batteryDetails.QIRemark);
                    //    spr.ForEach(a => a.Status = Int32.Parse(batteryDetails.Status));
                    //    //spr.ForEach(a => a.IssueLogCreateRes = batteryDetails.IssueLogCreateRes);
                    //    //spr.ForEach(a => a.IssueLogUpdateRes = batteryDetails.IssueLogUpdateRes);


                    //    await _context.SaveChangesAsync();
                    //    status = "Success";

                    //}


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

        [HttpPost("addImage")]
        public string postImage(string path, string issueID)
        {
            var baseUrl = "https://jira.atherengineering.in/rest/api/2/";

            userId = "JiraAutomation01";
            password = "uxTltVwrxrqMF8LVUrWc";

            string useridPwd = userId + ":" + password;
            Console.WriteLine(useridPwd);
            byte[] useridPwd_byt = System.Text.Encoding.UTF8.GetBytes(useridPwd);
            base64AuthString = Convert.ToBase64String(useridPwd_byt);

            string endpoint = baseUrl + "/issue/" + issueID + "/attachments";
            string method = "POST";

            //string json = JsonConvert.SerializeObject(ticket);


            //FileStream fs = getImage(path);






            WebClient wc = new WebClient();
            //string idpwb64 = "NUNfQ09NUDpBUEkjMTIzNA==";

            wc.Headers["Content-Type"] = "multipart/form-data; boundary=<calculated when request is sent>";
            wc.Headers["X-Atlassian-Token"] = "no-check";
            wc.Headers["Authorization"] = "Basic " + base64AuthString;
            wc.Headers["file"] = path.ToString();
            try
            {
                Console.WriteLine(endpoint);
                Console.WriteLine(method);
                Console.WriteLine(path);
                var responseAPI = wc.UploadFile(endpoint, method, path);

                Console.WriteLine("response:" + responseAPI);

                //                ResponseJiraSearch _response = JsonConvert.DeserializeObject<ResponseJiraSearch>(responseAPI);

                //return JsonConvert.DeserializeObject<SPResponse_DOWN>(response);
                return "Success";
            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now + " Api Operations exception: " + ", " + ex.ToString());

                return "Error: " + ex;
            }
        }

        public static FileStream getImage(string inputFilePath)
        {
            int bufferSize = 1024 * 1024;
            FileStream fs;
            //using (FileStream fileStream = new FileStream(outputFilePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
            //using (FileStream fs = File.Open(<file-path>, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                fs = new FileStream(inputFilePath, FileMode.Open, FileAccess.ReadWrite);
                //fileStream.SetLength(fs.Length);

                int bytesRead = -1;
                byte[] bytes = new byte[bufferSize];

                //while ((bytesRead = fs.Read(bytes, 0, bufferSize)) > 0)
                //{
                //    fileStream.Write(bytes, 0, bytesRead);
                //}
            }
            return fs;
        }
    }
}
