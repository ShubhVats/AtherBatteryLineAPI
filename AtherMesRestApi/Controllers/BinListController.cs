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
    [Route("api/GetBinList")]
    [ApiController]
    public class BinListController : ControllerBase
    {
        private readonly MESDBContext _context;

        public BinListController(MESDBContext context)
        {
            _context = context;
        }

        public List<BinList> BinLists { get; private set; }

        //GET: api/SapOrders/5

        [HttpGet("{status}/{line}")]
        public async Task<ActionResult<ResponseBinList>> GetBinList(int status, string line)
        {
            ResponseBinList responseBinList;

            BinList BinsLists;
            if (status == 100)
            {
                BinLists = await _context.BinList
                    .ToListAsync();

            }
            else
            {
                BinLists = await _context.BinList.Where(a => a.Status.Equals(status))
                     .ToListAsync();

            }

            if (BinLists == null)
            {
                responseBinList = new ResponseBinList("data not found", 300, null);
                //return NotFound();
            }
            else
            {
                if (BinLists.Count > 0)
                {
                    responseBinList = new ResponseBinList("data found", 200, BinLists);

                }
                else
                {
                    responseBinList = new ResponseBinList("data not found", 300, null);
                }
            }

            return responseBinList;
        }


        [HttpGet("Common/{status}/{reworkstation}")]
        public async Task<ActionResult<ResponseBinListCommon>> GetBinListCommon(int status, string reworkstation)
        {
            ResponseBinListCommon responseBinList;

            List<BinListCommon> BinsListss;
            BinsListss = await _context.BinListCommon.Where(a=>a.Status.Equals(status) && a.ReworkStationName.Equals(reworkstation))
                     .ToListAsync();

            if (BinsListss == null)
            {
                responseBinList = new ResponseBinListCommon("data not found", 300, null);
                //return NotFound();
            }
            else
            {
                if (BinsListss.Count > 0)
                {
                    responseBinList = new ResponseBinListCommon("data found", 200, BinsListss);

                }
                else
                {
                    responseBinList = new ResponseBinListCommon("data not found", 300, null);
                }
            }

            return responseBinList;
        }

    }
}
