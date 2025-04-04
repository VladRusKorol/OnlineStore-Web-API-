using Microsoft.EntityFrameworkCore;
using OnlineStore.Persistence;
using OnlineStore.Repository.Interfaces;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
namespace OnlineStore.Repository;

public abstract class AbstractRepositoryBase<T, TContext>(TContext pContext) : IRepositoryBase<T> where T : class where TContext: DbContext
{
    private protected TContext _context = pContext;

    virtual public async Task<int> CreateAsync(T entity)
    {
        _context.Set<T>().Add(entity);
        await _context.SaveChangesAsync();
        string primaryKeyName = getPrimaryKeyName();
        int maxValue = await GetMaxPrimaryKeyValueAsync();
        return maxValue;
    }

    virtual public async Task<int> DeleteAsync(int id)
    {
        T? deleteEntity = await _context.Set<T>().FindAsync(id);
        ArgumentNullException.ThrowIfNull(deleteEntity);
        await Task.Run(() => this._context.Set<T>().Remove(deleteEntity));
        await _context.SaveChangesAsync();
        return id;
    }

    virtual public async Task<List<T>?> GetAllAsync()
    {
        List<T> list = await _context.Set<T>().ToListAsync<T>();
        return list;
    }

    virtual public async Task<T> GetByIdAsync(int id)
    {
        T? findEntity = await _context.Set<T>().FindAsync(id);
        ArgumentNullException.ThrowIfNull(findEntity);
        return findEntity;
    }

    virtual public async Task<int> UpdateAsync(T entity)
    {
        string? keyName = getPrimaryKeyName();
        int id = EF.Property<int>(entity, keyName);
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
        return id;
    }

    private string getPrimaryKeyName()
    {
        return _context.Model.FindEntityType(typeof(T))!.FindPrimaryKey()!.Properties.Select(x => x.Name).Single();
    }

    public async Task<int> GetMaxPrimaryKeyValueAsync()
    {
        // Получаем информацию о первичном ключе
        Type type = typeof(T);
        PropertyInfo? primaryKeyProperty = type.GetProperty(getPrimaryKeyName());

        if (primaryKeyProperty == null)
        {
            throw new InvalidOperationException($"Property '{primaryKeyProperty}' not found on type '{type.Name}'.");
        }

        // Построение выражения для получения значения первичного ключа
        var parameter = Expression.Parameter(type, "x");
        var propertyAccess = Expression.Property(parameter, primaryKeyProperty);
        var lambda = Expression.Lambda<Func<T, int>>(propertyAccess, parameter);

        // Использование выражения в LINQ-запросе
        var maxValue = await _context.Set<T>().MaxAsync(lambda);

        return maxValue;
    }

}


/*
public virtual int GetKey(T entity)
    {
        
        string? keyName = _context.Model.FindEntityType(typeof(T))!.FindPrimaryKey()!.Properties.Select(x => x.Name).Single();
        return (int)entity.GetType()!.GetProperty(_primaryKeyName)!.GetValue(entity, null)!;
        
    }
*/