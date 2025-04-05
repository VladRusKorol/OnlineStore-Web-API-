using OnlineStore.Entity;
using OnlineStore.Persistence;
using System.Collections.Specialized;

namespace OnlineStore.Repository; 

public class ProductRepository(OnlineStoreDBContext pContext) : AbstractRepositoryBase<Product,OnlineStoreDBContext>(pContext)
{
    public override async Task<int> CreateAsync(Product entity)
    {
        Category? category = await _context.Categories.FindAsync(entity.CategoryId);
        ArgumentNullException.ThrowIfNull(category);
        entity.Category = category;
        _context.Add(entity);
        await _context.SaveChangesAsync();
        return entity.Id;
    }

    public override async Task<int> UpdateAsync(Product entity)
    {
        Category? category = await _context.Categories.FindAsync(entity.CategoryId);
        ArgumentNullException.ThrowIfNull(category);
        entity.Category = category;
        _context.Update(entity);
        await _context.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<Category> GetCategoryByIdAsync(int id)
    {
        Category? req = await _context.Categories.FindAsync(id);
        ArgumentNullException.ThrowIfNull(req);
        return req;
    }
}
