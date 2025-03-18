using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Pratice
{
    [Route("api/Get")]
    public class GetController : Controller
    {
       private ICategoryRepository CategoryRepository { get; set; }
        public GetController(ICategoryRepository categoryRepository)
        {
            this.CategoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Category> categories = CategoryRepository.GetCategories();
            return Ok(categories);
        }
    }

}
