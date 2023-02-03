using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ILogger<CategoriesController> _logger;
        private CategoryService _categoryService;

        public CategoriesController(ILogger<CategoriesController> logger, CategoryService categoryService)
        {
            _logger = logger;
            _categoryService = categoryService;
        }

        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return _categoryService.GetCategories();
        }

        [HttpGet("{id}")]
        public Category Get(int id)
        {
            return _categoryService.GetCategory(id);
        }

        [HttpPost]
        public void Post(string categoryName, string description)
        {
            _categoryService.CreateCategory(categoryName, description);
        }

        [HttpPut]
        public void Put(int id, string categoryName, string description)
        {
            _categoryService.UpdateCategory(id, categoryName, description);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _categoryService.DeleteCategory(id);
        }
    }
}
