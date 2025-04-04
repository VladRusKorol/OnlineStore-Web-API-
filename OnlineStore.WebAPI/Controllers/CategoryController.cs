using Microsoft.AspNetCore.Mvc;
using OnlineStore.Entity;
using OnlineStore.MapperDTO;
using OnlineStore.MapperDTO.CategoryDTO;
using OnlineStore.Repository;
using OnlineStore.Repository.Interfaces;
using SQLitePCL;

namespace OnlineStore.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController(IRepositoryBase<Category> CategoryRepository) : ControllerBase
    {
        private readonly CategoryRepository _context = (CategoryRepository)CategoryRepository;

        [HttpGet(Name = "GetAllAsyncCategories")]
        public async Task<List<Category>> GetAllAsync()
        {
            List<Category>? category = await _context.GetAllAsync();
            return category ?? [];
        }

        [HttpGet("{id}", Name = "GetByIdAsyncCategories")]
        public async Task<Category> GetByIdAsync(int id)
        {
            Category category = await _context.GetByIdAsync(id);
            return category;
        }

        [HttpPost(Name = "CreateCategory")]
        public async Task<int> CreateAsyncCategories([FromBody] CreateCategoryDTO newCategory)
        {

            var newId = await _context.CreateAsync(
                MapHelper.From_CreateCategoryDTO_To_Entity(newCategory)
            );
            return newId;
        }

        [HttpDelete("{id}",Name = "DeleteAsyncCategory")] 
        public async Task<int> DeleteAsyncCategories(int id)
        {
            var removeId = await _context.DeleteAsync(id);
            return removeId;
        }

        [HttpPut(Name = "UpdateAsynCategory")]
        public async Task UpdateAsync([FromBody] Category updCategory)
        {
            await _context.UpdateAsync(updCategory);
        }
        

    }
}
