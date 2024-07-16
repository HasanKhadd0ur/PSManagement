using PSManagement.SharedKernel.Entities;
using PSManagement.SharedKernel.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PSManagement.SharedKernel.Repositories
{
    public interface IRepository<T> where T :BaseEntity
    {
        Task<T> GetByIdAsync(int id, ISpecification<T> specification = null);
        Task<IEnumerable<T>> ListAsync();
        Task<IEnumerable<T>> ListAsync(ISpecification<T> specification);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
