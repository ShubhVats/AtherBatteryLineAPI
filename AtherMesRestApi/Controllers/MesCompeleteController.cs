using System;
using System.Threading.Tasks;
using AtherMesRestApi.MESModels;
using AtherMesRestApi.ResponseModel;
using Microsoft.AspNetCore.Mvc;

namespace AtherMesRestApi.Controllers
{
    [Route("api/mescompelete")]
    [ApiController]
    public class MesCompeleteController : ControllerBase
    {
        private readonly MESDBContext _context;

        public MesCompeleteController(MESDBContext context)
        {
            _context = context;
        }



        [HttpPost]
        public async Task<ActionResult<ResponseSave>> mesCompelete(MesCompeleteInput mesCompelete)
        {
            ResponseSave response;
            string status = string.Empty;
            DateTime date = DateTime.Now;

            MesCompelete mes = new MesCompelete(date, mesCompelete.BIN, mesCompelete.Station, mesCompelete.Message, mesCompelete.Value);

            var ipqcList = await _context.MesCompelete.AddAsync(mes);
            await _context.SaveChangesAsync();
            status = "Success";


            if (status == "Success")
            {
                response = new ResponseSave("Data saved successfully!", 200);
            }
            else
            {
                response = new ResponseSave("Data not saved.", 300);
            }

            return response;
        }
    }
}


