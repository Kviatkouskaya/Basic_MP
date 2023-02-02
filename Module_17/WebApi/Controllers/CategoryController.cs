using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;
        private CategoryService _categoryService;

        public CategoryController(ILogger<CategoryController> logger, CategoryService categoryService)
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
