using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AtherMesRestApi.MESModels;
using AtherMesRestApi.ResponseModel;
using System.Linq;

namespace AtherMesRestApi.Controllers
{
    [Route("api/subcategory")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        private readonly MESDBContext _context;

        public SubCategoryController(MESDBContext context)
        {
            _context = context;
        }


        [HttpGet("{line}")]
        public async Task<ActionResult<ResponseSubCategory>> GetSubCategory(string line)
        {
            ResponseSubCategory response;
            var subCategoryList = await _context.SubCategory
                 .ToListAsync();

            if (subCategoryList == null)
            {
                response = new ResponseSubCategory("data not found", 300, null);
                //return NotFound();
            }
            else
            {
                if (subCategoryList.Count > 0)
                {
                    response = new ResponseSubCategory("data found", 200, subCategoryList);

                }
                else
                {
                    response = new ResponseSubCategory("data not found", 300, null);
                }
            }

            return response;
        }
    }
}
