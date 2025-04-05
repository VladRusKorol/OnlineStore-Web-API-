using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Entity;
using OnlineStore.MapperDTO;
using OnlineStore.MapperDTO.ProductDTO;
using OnlineStore.Repository;
using OnlineStore.Repository.Interfaces;

namespace OnlineStore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IRepositoryBase<Product> ProductRepository) : ControllerBase
    {
        private readonly ProductRepository _context = (ProductRepository)ProductRepository;

        [HttpGet(Name = "GetAllAsyncProducts")]
        public async Task<List<ViewProductDTO>> GetAllAsync()
        {
            List<Product>? products = await _context.GetAllAsync();
            List<ViewProductDTO> req = new List<ViewProductDTO>();
            products.ForEach(async (item) =>
            {
                req.Add(await MapHelper.From_Entity_To_ViewProductDTO(item, _context));
            });
            return req ?? [];
        }

        [HttpGet("{id}", Name = "GetByIdAsyncProduct")]
        public async Task<ViewProductDTO> GetByIdAsync(int id)
        {
            Product product = await _context.GetByIdAsync(id);

            return await MapHelper.From_Entity_To_ViewProductDTO(product, _context);
        }

        [HttpPost(Name = "CreateProduct")]
        public async Task<int> CreateAsyncProduct([FromBody] CreateProductDTO newProduct)
        {
            var newId = await _context.CreateAsync(
                await MapHelper.From_CreateProductDTO_To_Entity(
                    newProduct, _context
                )
            );
            return newId;
        }

        [HttpDelete("{id}", Name = "DeleteAsyncProduct")]
        public async Task<int> DeleteAsyncCategories(int id)
        {
            var removeId = await _context.DeleteAsync(id);
            return removeId;
        }

        [HttpPut(Name = "UpdateAsynProduct")]
        public async Task UpdateAsync([FromBody] Product updProduct)
        {
            await _context.UpdateAsync(updProduct);
        }
    }
}
