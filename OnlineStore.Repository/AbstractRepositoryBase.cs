using Microsoft.EntityFrameworkCore;
using OnlineStore.Persistence;
using OnlineStore.Repository.Interfaces;
namespace OnlineStore.Repository;

public abstract class AbstractRepositoryBase<T, TContext>(TContext pContext) : IRepositoryBase<T> where T : class where TContext: DbContext
{
    private protected TContext _context = pContext;

    virtual public async Task<int> CreateAsync(T entity)
    {
        int id = GetKey(entity);
        _context.Set<T>().Add(entity);
        await _context.SaveChangesAsync();
        return id; 
    }

    virtual public async Task<int> DeleteAsync(int id)
    {
        T? deleteEntity = await _context.Set<T>().FirstOrDefaultAsync(x => (int)x.GetType()!.GetProperty("Id")!.GetValue(x, null)! == id);
        ArgumentNullException.ThrowIfNull(deleteEntity);
        await Task.Run(() => this._context.Set<T>().Remove(deleteEntity));
        await this._context.SaveChangesAsync();
        return id;
    }

    virtual public async Task<List<T>?> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    virtual public async Task<T> GetByIdAysnc(int id)
    {
        T? findEntity = await _context.Set<T>().FirstOrDefaultAsync(x => (int)x.GetType()!.GetProperty("Id")!.GetValue(x, null)! == id);
        ArgumentNullException.ThrowIfNull(findEntity);
        return findEntity;
    }

    virtual public async Task<int> UpdateAsync(T entity)
    {
        int id = GetKey(entity);
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
        return id;
    }

    public virtual int GetKey(T entity)
    {
        string? keyName = _context.Model
            .FindEntityType(typeof(T))!
            .FindPrimaryKey()!.Properties
            .Select(x => x.Name)
            .Single();
        return (int)entity.GetType()!.GetProperty(keyName)!.GetValue(entity, null)!;
    }
}
