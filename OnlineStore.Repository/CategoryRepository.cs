using Microsoft.EntityFrameworkCore;
using OnlineStore.Entity;
using OnlineStore.Persistence;
using OnlineStore.Repository.Interfaces;

namespace OnlineStore.Repository;

public class CategoryRepository(OnlineStoreDBContext pContext, string primaryKeyName) : AbstractRepositoryBase<Category, OnlineStoreDBContext>(pContext, primaryKeyName)
{

}

//public class CategoryRepository(OnlineStoreDBContext pContext) : IRepositoryBase<Category>
//{
//    public Task<int> CreateAsync(Category entity)
//    {
//        throw new NotImplementedException();
//    }

//    public Task<int> DeleteAsync(int id)
//    {
//        throw new NotImplementedException();
//    }

//    public async Task<List<Category>?> GetAllAsync()
//    {
//        return await pContext.Categories.ToListAsync();
//    }

//    public Task<Category> GetByIdAysnc(int id)
//    {
//        throw new NotImplementedException();
//    }

//    public int GetKey(Category entity)
//    {
//        throw new NotImplementedException();
//    }

//    public Task<int> UpdateAsync(Category entity)
//    {
//        throw new NotImplementedException();
//    }
//}