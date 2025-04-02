using Microsoft.AspNetCore.Mvc;
using OnlineStore.Entity;
using OnlineStore.Repository;
using OnlineStore.Repository.Interfaces;
using SQLitePCL;

namespace OnlineStore.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController(IRepositoryBase<Category> pCategoryRepository) : ControllerBase
    {
        CategoryRepository _context = (CategoryRepository)pCategoryRepository;

        [HttpGet(Name = "GetAllAsyncCategories")]
        public async Task<List<Category>> GetAllAsync()
        {
            List<Category>? category = await _context.GetAllAsync();
            return category ?? [];
        }

    }
}
