using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Repository.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<List<T>?> GetAllAsync();
        Task<T> GetByIdAysnc(int id);
        Task<int> CreateAsync(T entity); // создание объекта
        Task<int> UpdateAsync(T entity); // обновление объекта
        Task<int> DeleteAsync(int id); // удаление объекта по id
        int GetKey(T entity); //
    }
}
