using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtherMesRestApi.MESModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AtherMesRestApi.Controllers
{
    [Route("api/shift")]
    [ApiController]
    public class ShiftController : ControllerBase
    {
        private readonly MESDBContext _context;

        public ShiftController(MESDBContext context)
        {
            _context = context;
        }


        [HttpGet("line")]
        public async Task<ActionResult<ResponseShift>> GetShiftDetails(string line)
        {
            ResponseShift response;
            List<ShiftInformation> phaseList = new List<ShiftInformation>();
            var shiftList = await _context.ShiftInformation.ToListAsync();

            if (shiftList == null)
            {
                response = new ResponseShift("data not found", 300, null);
                //return NotFound();
            }
            else
            {
                if (shiftList.Count > 0)
                {
                    response = new ResponseShift("data found", 200, shiftList);

                }
                else
                {
                    response = new ResponseShift("data not found", 300, null);
                }
            }

            return response;
        }

        [HttpGet("binnumber")]
        public async Task<ActionResult<ResponseShift>> GetShiftDetailsMesProdPlan(string binnumber)
        {
            ResponseShift response;
            List<ShiftInformation> phaseList = new List<ShiftInformation>();
            var shiftList = await _context.ShiftInformation.ToListAsync();

            var mes_production_plan_sku = MES_PRODUCTION_PLAN_SKU(binnumber).Result;

            shiftList.ForEach(a => a.RunningSKU = mes_production_plan_sku);

            if (shiftList == null)
            {
                response = new ResponseShift("data not found", 300, null);
                //return NotFound();
            }
            else
            {
                if (shiftList.Count > 0)
                {
                    response = new ResponseShift("data found", 200, shiftList);

                }
                else
                {
                    response = new ResponseShift("data not found", 300, null);
                }
            }

            return response;
        }

        private async Task<string> MES_PRODUCTION_PLAN_SKU(string binnumber)
        {
            var sku = await _context.Prod_MESProductionPlan.Where(a => a.BIN_Number.Equals(binnumber)).FirstOrDefaultAsync();

            return sku.SKUId;
        }

    }

}
