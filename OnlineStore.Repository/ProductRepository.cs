using OnlineStore.Entity;
using OnlineStore.Persistence;
using System.Collections.Specialized;

namespace OnlineStore.Repository; 

public class ProductRepository(OnlineStoreDBContext pContext, string primaryKeyName) : AbstractRepositoryBase<Product,OnlineStoreDBContext>(pContext, primaryKeyName)
{
    public async Task<string> ToStringHello()
    {
        return await Task.Run(() => "Hello");
    } 
}
