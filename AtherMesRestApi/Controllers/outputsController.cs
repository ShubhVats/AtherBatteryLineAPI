using System;
using System.Threading.Tasks;
using AtherMesRestApi.MESModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AtherMesRestApi.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/outputs")]
    [ApiController]
    public class outputsController : ControllerBase
    {
        private readonly MESDBContext _context;

        public outputsController(MESDBContext context)
        {
            _context = context;
        }

        // POST: api/outputs
        [HttpPost]
        public async Task<ActionResult<string>> Getoutput()
        {
            try
            {
                var result = await _context.output.FromSqlRaw("exec CreateAppointment").ToListAsync();
                return "Success";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        [HttpGet("movegenealogy/{BIN}/{re_entry_station}")]
        public async Task<ActionResult<string>> Move_Geneaology(String BIN, int re_entry_station)
        {
            try
            {
                var result = await _context.output.FromSqlRaw("exec DataMovement_Station_GenologyFG  @Bin= " + BIN + ",@stationid ="+re_entry_station+ "").ToListAsync();
                return "Success";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
    }
}