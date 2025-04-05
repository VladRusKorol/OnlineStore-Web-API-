using OnlineStore.Entity;
using OnlineStore.MapperDTO.CategoryDTO;
using OnlineStore.MapperDTO.ProductDTO;
using OnlineStore.Persistence;
using OnlineStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.MapperDTO
{
    public static class MapHelper
    {
        public static Category From_CreateCategoryDTO_To_Entity(CreateCategoryDTO dto)
        {
            return new Category() { Name = dto.Name, Description = dto.Description }; 
        }

        public static async Task<Product> From_CreateProductDTO_To_Entity(CreateProductDTO dto, ProductRepository context)
        {
            Category? category = await context.GetCategoryByIdAsync(dto.CategoryId);
            ArgumentNullException.ThrowIfNull(category);
            return new Product() { Name = dto.Name, Description = dto.Description, CategoryId = category.Id, Price = dto.Price, Category = category};
        }

        public static async Task<ViewProductDTO> From_Entity_To_ViewProductDTO(Product entity, ProductRepository context)
        {
            Category? category = await context.GetCategoryByIdAsync(entity.CategoryId);
            return new ViewProductDTO() {Id = entity.Id, Name = entity.Name, Description = entity.Description, CategoryId = category.Id, Price = entity.Price, CategoryName = category.Name };
        }

    }
}
