using Microsoft.EntityFrameworkCore;
using OnlineStore.Entity;
using OnlineStore.Persistence;
using OnlineStore.Repository.Interfaces;

namespace OnlineStore.Repository;

public class CategoryRepository(OnlineStoreDBContext pContext, string primaryKeyName) : AbstractRepositoryBase<Category, OnlineStoreDBContext>(pContext, primaryKeyName)
{

}
