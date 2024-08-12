using Ardalis.Result;
using PSManagement.Application.Contracts.Authorization;
using PSManagement.Domain.Identity.DomainErrors;
using PSManagement.Domain.Identity.Entities;
using PSManagement.Domain.Identity.Repositories;
using PSManagement.Domain.Identity.Specification;
using PSManagement.SharedKernel.Repositories;
using PSManagement.SharedKernel.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Infrastructure.Services.Authorization
{
    public class UserRolesService : IUserRoleService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IRolesRepository _rolesRepository;
        private readonly BaseSpecification<User> _specification;

        public UserRolesService(
            IUsersRepository usersRepository,
            IRolesRepository rolesRepository)
        {
            _usersRepository = usersRepository;
            _rolesRepository = rolesRepository;
            _specification = new UserSpecification();
        }
        public async Task<Result> AssignUserToRole(string email, string roleName)
        {
            User user = await _usersRepository.GetByEmail(email,_specification);

            if (user is null) {

                return Result.Invalid(UserErrors.UnExistUser);
            }
            Role role = await _rolesRepository.GetByRoleName(roleName);
            
            if (role is null)
            {

                return Result.NotFound("UnExist Role.");
            }

            user.Roles.Add(role);
            return Result.Success();
        }

        public async Task<Result<List<string>>> GetUserRolesAsync(string email)
        {
            User user = await _usersRepository.GetByEmail(email, _specification);

            if (user is null)
            {

                return Result.Invalid(UserErrors.UnExistUser);
            }
            ;
            return Result.Success(user.Roles.Select(r => r.Name).ToList());
        }

        public async Task<bool> IsInRoleAsync(int userId, string roleName)
        {
            User user= await _usersRepository.GetByIdAsync(userId, _specification);
            if (user is null)
                return false;
            return user.Roles.Any(u => u.Name == roleName);
        }

        public async Task<Result> RemoveUserFromRole(string email, string roleName)
        {
            User user = await _usersRepository.GetByEmail(email, _specification);

            if (user is null)
            {

                return Result.Invalid(UserErrors.UnExistUser);
            }
            Role role = await _rolesRepository.GetByRoleName(roleName);

            if (role is null)
            {

                return Result.NotFound("UnExist Role.");
            }

            user.Roles.Remove(role);
            return Result.Success();

        }


    }
}
