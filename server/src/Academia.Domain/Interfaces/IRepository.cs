using System.Collections.Generic;
using System.Threading.Tasks;

using Academia.Domain.Entities;
namespace Academia.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<Usuario> Get(string username, string password);
        Task<T> InsertAsync(T item);
        Task<T> UpdateAsync(T item);
        Task<bool> DeleteAsync(long id);
        Task<T> SelectAsync(long id);
        Task<IEnumerable<T>> SelectAsync();
        Task<bool> ExistAsync(long id);
    }
}