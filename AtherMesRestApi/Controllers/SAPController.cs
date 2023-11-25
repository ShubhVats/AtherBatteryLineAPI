
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AtherMesRestApi.MESModels;
using AtherMesRestApi.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace AtherMesRestApi.Controllers
{
    [Route("api/SAP")]
    [ApiController]
    public class SAPController : Controller
    {

        private String baseUrl;
        private string userId;
        private string password;
        private string base64AuthString;

        private readonly MESDBContext _context;

        public ResponseParameterValue productionOrder;

        public SAPController(MESDBContext context)
        {
            _context = context;

        }

        //GET: api/SapOrders/5

        [HttpPost("milestone/dev")]
        public string postMilestoneDev(Milestones milestones)
        {
            var baseUrl = "http://atherpodev.atherengineering.in:50000/RESTAdapter/";
            //var baseUrl = "http://115.124.108.147:50000/RESTAdapter/";
            //http://atherpodev.atherengineering.in:50000/RESTAdapter/MES_MilestioneConfirm
            //userId = "RARUN";
            //password = "Admin@123";
            userId = "DSUPPORT";
            password = "SuppD@123";

            string useridPwd = userId + ":" + password;
            Console.WriteLine(useridPwd);
            byte[] useridPwd_byt = System.Text.Encoding.UTF8.GetBytes(useridPwd);
            base64AuthString = Convert.ToBase64String(useridPwd_byt);

            string endpoint = baseUrl + "MES_MilestioneConfirm";
            string method = "POST";


            string json = JsonConvert.SerializeObject(milestones);

            WebClient wc = new WebClient();
            //string idpwb64 = "NUNfQ09NUDpBUEkjMTIzNA==";

            wc.Headers["Content-Type"] = "application/json";
            wc.Headers["Authorization"] = "Basic " + base64AuthString;
            try
            {
                var responseAPI = wc.UploadString(endpoint, method, json);

                Console.WriteLine("response:" + responseAPI);

                //ResponseMC _response = JsonConvert.DeserializeObject<ResponseMC>(responseAPI);

                //return JsonConvert.DeserializeObject<SPResponse_DOWN>(response);
                return responseAPI;
            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now + " Api Operations exception: " + ", " + ex.ToString());

                return "Error: " + ex;
            }
        }

        [HttpPost("milestone/qi")]
        public string postMilestoneQI(Milestones milestones)
        {
            var baseUrl = "http://atherpoqas.atherengineering.in:50000/RESTAdapter/";
            //var baseUrl = "http://115.124.108.147:50000/RESTAdapter/";
            //http://atherpodev.atherengineering.in:50000/RESTAdapter/MES_MilestioneConfirm
            //userId = "RARUN";
            //password = "Admin@123";
            userId = "QSUPPORT";
            password = "SuppQ@123";

            string useridPwd = userId + ":" + password;
            Console.WriteLine(useridPwd);
            byte[] useridPwd_byt = System.Text.Encoding.UTF8.GetBytes(useridPwd);
            base64AuthString = Convert.ToBase64String(useridPwd_byt);

            string endpoint = baseUrl + "MES_MilestioneConfirm";
            string method = "POST";


            string json = JsonConvert.SerializeObject(milestones);

            WebClient wc = new WebClient();
            //string idpwb64 = "NUNfQ09NUDpBUEkjMTIzNA==";

            wc.Headers["Content-Type"] = "application/json";
            wc.Headers["Authorization"] = "Basic " + base64AuthString;
            try
            {
                var responseAPI = wc.UploadString(endpoint, method, json);

                Console.WriteLine("response:" + responseAPI);

                //ResponseMC _response = JsonConvert.DeserializeObject<ResponseMC>(responseAPI);

                //return JsonConvert.DeserializeObject<SPResponse_DOWN>(response);
                return responseAPI;
            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now + " Api Operations exception: " + ", " + ex.ToString());

                return "Error: " + ex;
            }
        }

        [HttpPost("milestone/prod")]
        public string postMilestoneProd(Milestones milestones)
        {
            var baseUrl = "http://atherpoprd.atherengineering.in:50000/RESTAdapter/";
            //var baseUrl = "http://115.124.108.147:50000/RESTAdapter/";
            //http://atherpodev.atherengineering.in:50000/RESTAdapter/MES_MilestioneConfirm
            //userId = "RARUN";
            //password = "Admin@123";
            userId = "Ather_MES";
            password = "MES@3210";

            string useridPwd = userId + ":" + password;
            Console.WriteLine(useridPwd);
            byte[] useridPwd_byt = System.Text.Encoding.UTF8.GetBytes(useridPwd);
            base64AuthString = Convert.ToBase64String(useridPwd_byt);

            string endpoint = baseUrl + "MES_MilestioneConfirm";
            string method = "POST";


            string json = JsonConvert.SerializeObject(milestones);

            WebClient wc = new WebClient();
            //string idpwb64 = "NUNfQ09NUDpBUEkjMTIzNA==";

            wc.Headers["Content-Type"] = "application/json";
            wc.Headers["Authorization"] = "Basic " + base64AuthString;
            try
            {
                var responseAPI = wc.UploadString(endpoint, method, json);

                Console.WriteLine("response:" + responseAPI);

                //ResponseMC _response = JsonConvert.DeserializeObject<ResponseMC>(responseAPI);

                //return JsonConvert.DeserializeObject<SPResponse_DOWN>(response);
                return responseAPI;
            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now + " Api Operations exception: " + ", " + ex.ToString());

                return "Error: " + ex;
            }
        }

        [HttpPost("productionbooking/dev")]
        public string postProductionBookingDev(ProdBooking prodBooking)
        {

            var baseUrl = "http://atherpodev.atherengineering.in:50000/RESTAdapter/";
            //var baseUrl = "HTTP://115.124.108.147:50000/RESTAdapter/";

            //userId = "RARUN";
            //password = "Admin@123";
            userId = "DSUPPORT";
            password = "SuppD@123";
            string useridPwd = userId + ":" + password;
            Console.WriteLine(useridPwd);
            byte[] useridPwd_byt = System.Text.Encoding.UTF8.GetBytes(useridPwd);
            base64AuthString = Convert.ToBase64String(useridPwd_byt);

            string endpoint = baseUrl + "MES_ProdOrderGR";
            string method = "POST";
            string json = JsonConvert.SerializeObject(prodBooking);

            Console.WriteLine(json);

            WebClient wc = new WebClient();
            wc.Headers["Content-Type"] = "application/json";
            wc.Headers["Authorization"] = "Basic " + base64AuthString;
            try
            {

                var responseAPI = wc.UploadString(endpoint, method, json);

                Console.WriteLine("response:" + responseAPI);

                //ResponsePB _response = JsonConvert.DeserializeObject<ResponsePB>(responseAPI);

                //Console.WriteLine(_response.ToString());
                //return JsonConvert.DeserializeObject<SPResponse_DOWN>(response);
                return responseAPI;
            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now + " Api Operations exception: " + " " + ex.ToString());
                return "Error: " + ex;


            }

        }

        [HttpPost("productionbooking/qi")]
        public string postProductionBookingQI(ProdBooking prodBooking)
        {

            //var baseUrl = "http://atherpodev.atherengineering.in:50000/RESTAdapter/";
            var baseUrl = "http://atherpoqas.atherengineering.in:50000/RESTAdapter/";
            //var baseUrl = "HTTP://115.124.108.147:50000/RESTAdapter/";

            //userId = "RARUN";
            //password = "Admin@123";
            userId = "QSUPPORT";
            password = "SuppQ@123";
            string useridPwd = userId + ":" + password;
            Console.WriteLine(useridPwd);
            byte[] useridPwd_byt = System.Text.Encoding.UTF8.GetBytes(useridPwd);
            base64AuthString = Convert.ToBase64String(useridPwd_byt);

            string endpoint = baseUrl + "MES_ProdOrderGR";
            string method = "POST";
            string json = JsonConvert.SerializeObject(prodBooking);

            Console.WriteLine(json);

            WebClient wc = new WebClient();
            wc.Headers["Content-Type"] = "application/json";
            wc.Headers["Authorization"] = "Basic " + base64AuthString;
            try
            {

                var responseAPI = wc.UploadString(endpoint, method, json);

                Console.WriteLine("response:" + responseAPI);

                //ResponsePB _response = JsonConvert.DeserializeObject<ResponsePB>(responseAPI);

                //Console.WriteLine(_response.ToString());
                //return JsonConvert.DeserializeObject<SPResponse_DOWN>(response);
                return responseAPI;
            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now + " Api Operations exception: " + " " + ex.ToString());
                return "Error: " + ex;


            }

        }

        [HttpPost("productionbooking/Prod")]
        public string postProductionBookingProd(ProdBooking prodBooking)
        {

            var baseUrl = "http://atherpoprd.atherengineering.in:50000/RESTAdapter/";
            //var baseUrl = "HTTP://115.124.108.147:50000/RESTAdapter/";

            //userId = "RARUN";
            //password = "Admin@123";
            userId = "Ather_MES";
            password = "MES@3210";
            string useridPwd = userId + ":" + password;
            Console.WriteLine(useridPwd);
            byte[] useridPwd_byt = System.Text.Encoding.UTF8.GetBytes(useridPwd);
            base64AuthString = Convert.ToBase64String(useridPwd_byt);

            string endpoint = baseUrl + "MES_ProdOrderGR";
            string method = "POST";
            string json = JsonConvert.SerializeObject(prodBooking);

            Console.WriteLine(json);

            WebClient wc = new WebClient();
            wc.Headers["Content-Type"] = "application/json";
            wc.Headers["Authorization"] = "Basic " + base64AuthString;
            try
            {

                var responseAPI = wc.UploadString(endpoint, method, json);

                Console.WriteLine("response:" + responseAPI);

                //ResponsePB _response = JsonConvert.DeserializeObject<ResponsePB>(responseAPI);

                //Console.WriteLine(_response.ToString());
                //return JsonConvert.DeserializeObject<SPResponse_DOWN>(response);
                return responseAPI;
            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now + " Api Operations exception: " + " " + ex.ToString());
                return "Error: " + ex;


            }

        }

        [HttpPost("keycomponents")]
        public async Task<ResponseSave> postKeyComponents(SAP_KEY_COMPONENT_BOOKING_INPUT component)
        {

            string status = string.Empty;
            ResponseSave responseSave;

            //If key component is updated in DB
            if (component.Key_Component_ID == null || component.Key_Component_ID.Equals("") || component.Production_Order_No == null || component.Production_Order_No.Equals(""))
            {
                //Getting Details from SAP common table
                SAP_KEY_COMPONENT_BOOKING obj = new SAP_KEY_COMPONENT_BOOKING();

                try
                {
                    var sapKeyComp = await _context.SAP_KEY_COMPONENT_BOOKING.Where(a => a.BIN_Number.Equals(component.BIN_Number) && a.Key_Component_Type.Equals(component.Key_Component_Type)).FirstOrDefaultAsync();

                    sapKeyComp.Key_Component_Serial_No = component.Key_Component_Serial_No;

                    await _context.SaveChangesAsync();
                    status = "Success";

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    status = "Failure";
                }


            }

            //If key component is added to the DB
            else
            {
                var ComponentList = await _context.SAP_KEY_COMPONENT_BOOKING.Where(a => a.BIN_Number.Equals(component.BIN_Number) && a.Key_Component_ID.Equals(component.Key_Component_ID)).ToListAsync();

                if (component.Key_Component_Type == null)//Updating null value to empty string
                {
                    component.Key_Component_Type = "";
                }

                if (ComponentList.Count > 0)//If bin exists update the serial number
                {
                    //ComponentList.ForEach(a => a.Production_Order_No = component.Production_Order_No);
                    ComponentList.ForEach(a => a.Key_Component_Serial_No = component.Key_Component_Serial_No);

                    await _context.SaveChangesAsync();
                    status = "Success";

                }
                else//add new object
                {
                    SAP_KEY_COMPONENT_BOOKING obj = new(component.Production_Order_No, component.BIN_Number, component.Key_Component_ID, component.Key_Component_Serial_No, component.Key_Component_Type);

                    try
                    {

                        _context.SAP_KEY_COMPONENT_BOOKING.Add(obj);
                        await _context.SaveChangesAsync();
                        status = "Success";

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        status = "Failure";
                    }
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

        [HttpGet("getkeycomponents/{binnumber}/{parameterid}")]
        public async Task<ResponseParameterValue> getKeyComponents(string binnumber, string parameterid)
        {

            string status = string.Empty;
            ResponseParameterValue responseSave;
            SAP_KEY_COMPONENT_BOOKING sap = new SAP_KEY_COMPONENT_BOOKING();



            try
            {
                sap = await _context.SAP_KEY_COMPONENT_BOOKING.Where(a => a.BIN_Number.Equals(binnumber) && a.Key_Component_Type.Equals(parameterid)).FirstAsync();

                status = "Success";

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                status = "Failure";
            }

            if (status == "Success")
            {
                responseSave = new ResponseParameterValue("Data saved successfully!", 200, sap.Key_Component_Serial_No);
            }
            else
            {
                responseSave = new ResponseParameterValue("Data not saved.", 300, null);
            }

            return responseSave;

        }


        [HttpGet("getkeycomponents/{binnumber}")]
        public async Task<ResponseKeyComponents> getKeyComponentCommon(string binnumber)
        {

            string status = string.Empty;
            ResponseKeyComponents responseSave;
            List<SAP_KEY_COMPONENT_BOOKING> saps = new List<SAP_KEY_COMPONENT_BOOKING>();



            try
            {
                saps = await _context.SAP_KEY_COMPONENT_BOOKING.Where(a => a.BIN_Number.Equals(binnumber)).ToListAsync();

                status = "Success";

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                status = "Failure";
            }

            if (status == "Success")
            {
                responseSave = new ResponseKeyComponents("Data saved successfully!", 200, saps);
            }
            else
            {
                responseSave = new ResponseKeyComponents("KEY COMPONENET SCANNING NOT DONE.", 300, saps);
            }

            return responseSave;

        }

        [HttpGet("productionorder/{binnumber}")]
        public async Task<ResponseParameterValue> getproductionorder(string binnumber)
        {
            string status = string.Empty;

            ResponseParameterValue parameterValue;
            Prod_MESProductionPlan parameter = new Prod_MESProductionPlan();
            try
            {
                parameter = await _context.Prod_MESProductionPlan.Where(a => a.BIN_Number.Equals(binnumber)).FirstAsync();
                status = "Success";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                status = "Failure";
            }



            if (status != "Success")
            {
                parameterValue = new ResponseParameterValue("data not found", 300, null);
                //return NotFound();
            }
            else
            {
                parameterValue = new ResponseParameterValue("data found", 200, parameter.Production_Order_No);
            }

            return parameterValue;
        }

        [HttpGet]
        public async Task<ResponseParameterValue> getproductionorder()
        {
            string status = string.Empty;

            ResponseParameterValue parameterValue;
            Prod_MESProductionPlan parameter = new Prod_MESProductionPlan();
            try
            {
                Console.WriteLine("PBUpdate");

                var checkList = _context.SAP_Mileston_Response.Where(a => a.MessageType.Equals("0"))
                     .ToList();

                List<ResponseMC> Userlist = new List<ResponseMC>();

                for (int i = 0; i < checkList.Count; i++)
                {
                    ResponseMC _response = JsonConvert.DeserializeObject<ResponseMC>(checkList[i].ResponseBody);

                    string messages = "";

                    for (int j = 0; j < _response.MT_Milestone_confirm_Resp.response.Count(); j++)
                    {
                        messages = messages + _response.MT_Milestone_confirm_Resp.response[j].messageType + " , ";
                    }

                    checkList.ForEach(a => a.MessageType = messages);

                }
                _context.SaveChanges();
                status = "Success";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                status = "Failure";
            }



            if (status != "Success")
            {
                parameterValue = new ResponseParameterValue("data not found", 300, null);
                //return NotFound();
            }
            else
            {
                parameterValue = new ResponseParameterValue("data found", 200, parameter.Production_Order_No);
            }

            return parameterValue;
        }


        [HttpGet("component_id/{prod_order_no}")]
        public async Task<ResponseSAPOrderKeyComponent> getComponentID(string prod_order_no)
        {
            ResponseSAPOrderKeyComponent response;
            string status = "";
            string Error = "";

            List<SapProductionKeyComponents> prodList = new List<SapProductionKeyComponents>();
            //prodList.Clear();

            try
            {

                prodList = await _context.SapProductionKeyComponents.Where(a => a.Production_Order_No.Equals(prod_order_no)).ToListAsync();

            }
            catch (Exception e)
            {
                status = "Failed" + e;
                Console.WriteLine(status);
                Error = e.Message.ToString();
            }

            if (prodList.Count > 0)
            {
                response = new ResponseSAPOrderKeyComponent("Data found.", 200, prodList);
            }
            else
            {
                response = new ResponseSAPOrderKeyComponent("Data not found.", 300, null);
            }


            return response;



        }


    }
}