using PSManagement.SharedKernel.Entities;
using PSManagement.SharedKernel.Interfaces;
using System.Collections.Generic;

using System.Threading.Tasks;

namespace PSManagement.SharedKernel.Repositories
{
    public interface IReadRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<List<T>> ListAsync();
        Task<List<T>> ListAsync(ISpecification<T> spec);
    }
}
