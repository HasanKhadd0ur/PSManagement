using FluentResults;
using PSManagement.Application.Contracts.Authorization;
using PSManagement.Domain.Identity.Entities;
using PSManagement.SharedKernel.DomainException;
using PSManagement.SharedKernel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Infrastructure.Services.Authorization
{
    public class RoleService : IRoleService
    {
        private readonly IRepository<Role> _roleRepository;

        public RoleService(IRepository<Role> roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<Result> CreateRoleAsync(string roleName)
        {
            var role_exist =await _roleRepository.ListAsync();
            role_exist = role_exist.Where(e => e.Name == roleName);

            if (role_exist is null ) // check role exist status
            {
                var result = await _roleRepository.AddAsync(new Role { Name= roleName});

                // check if the role has been added succesfully
                if (result is not null )
                {
                    return Result.Ok();
                }
                else
                {
                    return Result.Fail(new Error("Failed to add the role."));
                }
            }
            return Result.Fail(new Error("Failed to add the role."));
        }

        public async Task<Result> DeleteRoleAsync(int roleId)
        {
            var roleDetails = await _roleRepository.GetByIdAsync(roleId);
            if (roleDetails == null)
            {
                return Result.Fail(new Error("The Role Not Found."));
            }

            if (roleDetails.Name == "Admin")
            {
                return Result.Fail(new Error("You Cannot Remove the admin role."));
            }
          
            await _roleRepository.DeleteAsync(roleDetails);

            return Result.Ok() ;

        }

        public async Task<Result<Role>> GetRoleByIdAsync(int id)
        {
            var roles =await  _roleRepository.GetByIdAsync(id);
            if (roles is null) {
                return Result.Fail(new Error("The Role not found."));
            }
            return Result.Ok(roles);

        }

        public async Task<List<Role>> GetRolesAsync()
        {
            var result =await _roleRepository.ListAsync();
            return result.ToList();
        }

        public async Task<Result<Role>> UpdateRole(int id, string roleName)
        {
            var role = await _roleRepository.GetByIdAsync(id);
            if (role is null)
            {
                return Result.Fail(new Error("The Role not found."));
            }
            role.Name = roleName;
            role = await _roleRepository.UpdateAsync(role);

            return Result.Ok(role);
        }
    }
}
