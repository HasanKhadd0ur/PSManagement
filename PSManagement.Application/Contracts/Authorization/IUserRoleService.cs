using FluentResults;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PSManagement.Application.Contracts.Authorization
{
    public interface IUserRoleService
    {
        Task<bool> IsInRoleAsync(int userId, string role);
        Task<List<string>> GetUserRolesAsync(string email);
        Task<Result> AssignUserToRole(string userName, string roleName);
        Task UpdateUsersRole(string userName, string usersRole);
        Task<Result> RemoveUserFromRole(string email, string roleName);
    }

}
