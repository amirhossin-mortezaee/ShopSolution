using OnlineShop.Domain.Commons;
using Shop.Domain.Commons;

namespace Shop.Application.Interfaces
{
    public interface IRepository<T> where T : BaseEntity , IAggregateRoot
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
