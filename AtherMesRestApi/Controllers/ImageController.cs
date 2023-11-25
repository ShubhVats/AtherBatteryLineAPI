using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AtherMesRestApi.MESModels;
using AtherMesRestApi.ResponseModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace AtherMesRestApi.Controllers
{
    //[ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/image")]
    [ApiController]
    public class ImageUploadController : ControllerBase
    {
        public static IWebHostEnvironment _environment;
        private readonly MESDBContext _context;

        public ImageUploadController(IWebHostEnvironment environment, MESDBContext context)
        {
            _environment = environment;
            _context = context;

        }


        [HttpPost]
        public Task<common> Post([FromForm] FileUploadAPI objFile)
        {
            common obj = new common();
            obj.LstCustomer = new List<Customer>();
            obj._fileAPI = new FileUploadAPI();
            try
            {
                List<Customer> list = JsonConvert.DeserializeObject<List<Customer>>(objFile.Customers);
                obj.LstCustomer = list;
                obj._fileAPI.ImgID = objFile.ImgID;
                obj._fileAPI.ImgName = "\\Applications\\QIImage-New\\" + objFile.files.FileName;
                if (objFile.files.Length > 0)
                {
                    if (!Directory.Exists(_environment.WebRootPath + "\\Applications\\QIImage-New"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "\\Applications\\QIImage-New\\");
                        Console.WriteLine(Directory.CreateDirectory(_environment.WebRootPath + "\\Applications\\QIImage-New\\"));

                    }
                    using (FileStream filestream = System.IO.File.Create(_environment.WebRootPath + "\\Applications\\QIImage-New\\" + objFile.files.FileName))
                    {
                        objFile.files.CopyTo(filestream);
                        Console.WriteLine(Directory.CreateDirectory(_environment.WebRootPath + "\\Applications\\QIImage-New\\" + objFile.files.FileName));
                        filestream.Flush();
                        //  return "\\Upload\\" + objFile.files.FileName;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return Task.FromResult(obj);
        }

        [HttpPost("Upload")]
        public async Task<ActionResult<ResponseSave>> UploadImage([FromForm] Quality_DHCImage quality_DHC, [FromForm] FileUploadAPI2 objFile)
        {
            ResponseSave response;
            String result = "";
            common2 obj = new common2();
            obj._fileAPI = new FileUploadAPI2();
            byte[] bytes;
            byte[] bytess = new byte[0];
            try
            {

                obj._fileAPI.ImgName = "\\Applications\\QIImage-New\\" + objFile.ImgName;
                if (objFile.files.Length > 0)
                {
                    //Image Upload Server
                    if (!Directory.Exists(_environment.WebRootPath + "\\Applications\\QIImage-New"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "\\Applications\\QIImage-New\\");
                    }
                    using (FileStream filestream = System.IO.File.Create(_environment.WebRootPath + "\\Applications\\QIImage-New\\" + objFile.ImgName))
                    {
                        objFile.files.CopyTo(filestream);


                        var stream = new MemoryStream((int)objFile.files.Length);
                        objFile.files.CopyTo(stream);
                        bytes = stream.ToArray();


                        filestream.Flush();
                    }
                    result = "Success";


                    //Data Upload
                    DateTime d = DateTime.Now;
                    quality_DHC.ImagePath = "http:\\\\192.168.201.244:8083\\" + objFile.ImgName;
                    Console.WriteLine(quality_DHC.ImagePath);
                    quality_DHC.Timestamp = d;

                    _context.Quality_DHCImage.Add(quality_DHC);
                    await _context.SaveChangesAsync();
                    result = "Success";


                    //Image Upload JIRA
                    var jiraRes = await postImage2JIRAa(objFile, quality_DHC.BIN_Number);
                    result = jiraRes.ToString();
                }
                else
                {
                    result = "Duplicate image name.";
                }
            }
            catch (Exception ex)
            {
                result = "" + ex.Message;
            }

            if (result == "Success")
            {
                response = new ResponseSave("Data saved successfully!", 200);
            }
            else
            {
                response = new ResponseSave("Data not saved. " + result, 300);
            }

            return response;
        }


        [HttpGet("Download/{BIN_Number}")]
        public async Task<ActionResult<ResponseQuality_DHCImage>> DownloadImage(string BIN_Number)
        {
            ResponseQuality_DHCImage response;
            String result = "";
            List<Quality_DHCImage> item = new List<Quality_DHCImage>();

            try
            {

                item = await _context.Quality_DHCImage.Where(a => a.BIN_Number.Equals(BIN_Number) && a.IsDelete == false).ToListAsync();
                //await _context.SaveChangesAsync();
                result = "Success";

            }
            catch (Exception e)
            {
                result = e.Message.ToString();
            }


            if (item == null)
            {
                response = new ResponseQuality_DHCImage("Data not found. Error: " + result, 300, null);
            }
            else
            {
                if (item.Count > 0)
                {
                    response = new ResponseQuality_DHCImage("Data found.", 200, item);
                }
                else
                {
                    response = new ResponseQuality_DHCImage("Data not found.", 300, null);
                }

            }

            return response;
        }

        [HttpGet("Delete/{RowID}")]
        public async Task<ActionResult<ResponseSave>> DeleteImage(string RowID)
        {
            ResponseSave response;
            string status = string.Empty;

            String Error = "";

            int rowIDInt = Int32.Parse(RowID);
            try
            {
                await _context.output.FromSqlRaw("EXEC [ImageDeleteStatus] " + rowIDInt + "").ToListAsync();
                status = "Success";

            }
            catch (Exception e)
            {
                status = "Failed" + e;
                Console.WriteLine(status);
                Error = e.Message.ToString();
            }
            if (true)
            {
                response = new ResponseSave("Data deleted successfully!", 200);
            }
            else
            {
                response = new ResponseSave("Data not deleted. Error : " + Error, 300);
            }

            return response;
        }

        [HttpPost("JIRA")]

        public async Task<string> postImage2JIRAa([FromForm] FileUploadAPI2 objFile, string binnum)
        {

            try
            {


                var issues = await _context.JIRA_Send_Data.Where(a => a.BIN_Number.Equals(binnum) && a.Ticket_Number != null).ToListAsync();

                //var issue = await _context.SAP_JIRA_Response.Where(a => a.BIN_Number.Equals(binnum)).FirstOrDefaultAsync();

                byte[] bytes = new byte[objFile.files.Length];
                using (var streamm = objFile.files.OpenReadStream())
                {
                    streamm.Read(bytes, 0, bytes.Length);

                }
                using var fileContent = new ByteArrayContent(bytes);

                //var stream = new MemoryStream((int)objFile.files.Length);
                //objFile.files.CopyTo(stream);
                //bytes = stream.ToArray();

                Boolean imageSendStatus = true;

                foreach (JIRA_Send_Data issue in issues)
                {
                    var client = new HttpClient();
                    var request = new HttpRequestMessage(HttpMethod.Post, "https://jira.atherengineering.in/rest/api/2/issue/" + issue.Ticket_Number + "/attachments");
                    request.Headers.Add("X-Atlassian-Token", "no-check");
                    request.Headers.Add("Authorization", "Basic SmlyYUF1dG9tYXRpb24wMTp1eFRsdFZ3cnhycU1GOExWVXJXYw==");
                    var content = new MultipartFormDataContent();
                    content.Add(fileContent, "file", objFile.ImgName);
                    request.Content = content;
                    var response = await client.SendAsync(request);
                    var res = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                    {
                        //imageSendStatus = false; //To be uncommented when NULL is removed from ticketNumber Entry
                    }
                }


                //response.EnsureSuccessStatusCode();
                //Console.WriteLine(response.Content.ReadAsStringAsync());
                //Console.WriteLine(response.StatusCode);

                if (imageSendStatus)
                {
                    return "Success";
                }
                else
                {
                    return "Failed";
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now + " Api Operations exception: " + ", " + ex.ToString());

                return "Failed";

            }
        }



        [HttpPost("JIRAJIRA")]

        public async Task<string> postImage2JIRAaa(string binnum)
        {

            try
            {

                var ImagesList = await _context.Quality_DHCImage.Where(a => a.BIN_Number.Equals(binnum) && a.IsDelete.Equals(false)).ToListAsync();
                var issues = await _context.JIRA_Send_Data.Where(a => a.BIN_Number.Equals(binnum) && a.Ticket_Number != null).ToListAsync();

                IEnumerable<string> distinctIssues =  issues.Select(x => x.Ticket_Number).Distinct();

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


                        foreach (string issue in distinctIssues)
                        {
                            var client = new HttpClient();
                            var request = new HttpRequestMessage(HttpMethod.Post, "https://jira.atherengineering.in/rest/api/2/issue/" + issue+ "/attachments");
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