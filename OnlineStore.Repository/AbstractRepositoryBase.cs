using Microsoft.EntityFrameworkCore;
using OnlineStore.Persistence;
using OnlineStore.Repository.Interfaces;
using System.Linq;
namespace OnlineStore.Repository;

public abstract class AbstractRepositoryBase<T, TContext>(TContext pContext, string primaryKeyName) : IRepositoryBase<T> where T : class where TContext: DbContext
{
    private protected TContext _context = pContext;
    private protected string _primaryKeyName = primaryKeyName;
    virtual public async Task<int> CreateAsync(T entity)
    {
        int id = EF.Property<int>(entity, _primaryKeyName);
        _context.Set<T>().Add(entity);
        await _context.SaveChangesAsync();
        return id; 
    }

    virtual public async Task<int> DeleteAsync(int id)
    {
        /*T? deleteEntity = await _context.Set<T>().Find(id); Если id является первичным ключом, вы можете использовать метод Find, который оптимизирован для поиска по первичному ключу:*/
        T? deleteEntity = await _context.Set<T>().FirstOrDefaultAsync(x => EF.Property<int>(x, _primaryKeyName) == id);
        ArgumentNullException.ThrowIfNull(deleteEntity);
        await Task.Run(() => this._context.Set<T>().Remove(deleteEntity));
        await this._context.SaveChangesAsync();
        return id;
    }

    virtual public async Task<List<T>?> GetAllAsync()
    {
        List<T> list = await _context.Set<T>().ToListAsync<T>();
        return list;
    }

    virtual public async Task<T> GetByIdAsync(int id)
    {
        /*T? findEntity = await _context.Set<T>().Find(id); Если id является первичным ключом, вы можете использовать метод Find, который оптимизирован для поиска по первичному ключу:*/
        T? findEntity = await _context.Set<T>().FirstOrDefaultAsync(x => EF.Property<int>(x, _primaryKeyName) == id );
        ArgumentNullException.ThrowIfNull(findEntity);
        return findEntity;
    }

    virtual public async Task<int> UpdateAsync(T entity)
    {
        int id = EF.Property<int>(entity, _primaryKeyName);
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
        return id;
    }

    //public virtual int GetKey(T entity)
    //{
    //    /*
    //    string? keyName = _context.Model.FindEntityType(typeof(T))!.FindPrimaryKey()!.Properties.Select(x => x.Name).Single();
    //    return (int)entity.GetType()!.GetProperty(_primaryKeyName)!.GetValue(entity, null)!;
    //    */
    //}
}
