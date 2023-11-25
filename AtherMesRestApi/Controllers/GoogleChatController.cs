using System;
using System.Linq;
using System.Threading.Tasks;
using AtherMesRestApi.MESModels;
using AtherMesRestApi.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AtherMesRestApi.Controllers
{
    [Route("api/GC")]
    [ApiController]
    public class GoogleChatController : Controller
    {
        private readonly MESDBContext _context;

        public GoogleChatController(MESDBContext context)
        {
            _context = context;
        }

        //GET: api/SapOrders/5




        [HttpPost]
        public async Task<ActionResult<ResponseSave>> setGoogleChat(GoogleChat googleChat)
        {

            ResponseSave responseSave;
            string status = string.Empty;
            UpdateGoogleChat chat = new(Convert.ToDateTime(googleChat.Timestamp), Int32.Parse(googleChat.Msg_Type), googleChat.Line_No, googleChat.StationName, googleChat.Assetid, Int32.Parse(googleChat.Severity), googleChat.Message, Int32.Parse(googleChat.MSGStatus));

            _context.GoogleChat.Add(chat);
            await _context.SaveChangesAsync();
            status = "Success";

            if (status == "Success")
            {
                responseSave = new ResponseSave("Message sent successfully!", 200);
            }
            else
            {
                responseSave = new ResponseSave("Message not sent.", 300);
            }

            return responseSave;
        }
    }
}
