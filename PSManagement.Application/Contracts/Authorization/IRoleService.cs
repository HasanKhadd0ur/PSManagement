using FluentResults;
using PSManagement.Domain.Identity.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Application.Contracts.Authorization
{
    public interface IRoleService
    {
        Task<Result> CreateRoleAsync(string roleName);
        Task<Result> DeleteRoleAsync(int roleId);
        Task<List<Role>> GetRolesAsync();
        Task<Result<Role>> GetRoleByIdAsync(int id);
        Task<Result<Role>> UpdateRole(int id, string roleName);
    }

}
