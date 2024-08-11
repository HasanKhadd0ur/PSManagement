using PSManagement.Domain.Identity.Entities;
using PSManagement.SharedKernel.Interfaces;
using PSManagement.SharedKernel.Repositories;
using System.Threading.Tasks;

namespace PSManagement.Domain.Identity.Repositories
{
    public interface IRolesRepository : IRepository<Role>
    {
        public Task<Role> GetByRoleName(string roleName, ISpecification<Role> specification = null);
    }
}
