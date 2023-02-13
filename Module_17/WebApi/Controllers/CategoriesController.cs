using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ILogger<CategoriesController> _logger;

        private readonly CategoryRepository<Category> _categoryRepository;

        public CategoriesController(ILogger<CategoriesController> logger,
            CategoryRepository<Category> categoryRepository)
        {
            _logger = logger;
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return _categoryRepository.GetItems();
        }

        [HttpGet("{id}")]
        public Category Get(int id)
        {
            return _categoryRepository.GetItem(id);
        }

        [HttpPost]
        public void Post(string categoryName, string description)
        {
            _categoryRepository.CreateItem(new Category()
            {
                CategoryName = categoryName,
                Description = description
            });
        }

        [HttpPut]
        public void Put(int id, string categoryName, string description)
        {
            _categoryRepository.UpdateItem(new Category()
            {
                CategoryID = id,
                CategoryName = categoryName,
                Description = description
            });
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _categoryRepository.DeleteItem(id);
        }
    }
}
