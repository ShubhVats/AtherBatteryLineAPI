using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AtherMesRestApi.MESModels;
using AtherMesRestApi.ResponseModel;
using System.Linq;

namespace AtherMesRestApi.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly MESDBContext _context;

        public CategoryController(MESDBContext context)
        {
            _context = context;
        }


        [HttpGet("{line}")]
        public async Task<ActionResult<ResponseCategory>> GetSubCategory(string line)
        {
            ResponseCategory response;
            var categoryList = await _context.Category
                 .ToListAsync();

            if (categoryList == null)
            {
                response = new ResponseCategory("data not found", 300, null);
                //return NotFound();
            }
            else
            {
                if (categoryList.Count > 0)
                {
                    response = new ResponseCategory("data found", 200, categoryList);

                }
                else
                {
                    response = new ResponseCategory("data not found", 300, null);
                }
            }

            return response;
        }
    }
}
