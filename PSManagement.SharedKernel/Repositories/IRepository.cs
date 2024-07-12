using PSManagement.SharedKernel.Entities;
using PSManagement.SharedKernel.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PSManagement.SharedKernel.Repositories
{
    public interface IRepository<T> where T :BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<List<T>> ListAsync();
        Task<List<T>> ListAsync(ISpecification<T> spec);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
