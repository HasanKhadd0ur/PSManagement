
using FluentResults;
using PSManagement.Application.Contracts.Authentication;
using PSManagement.Application.Contracts.Authorization;
using PSManagement.Domain.Customers.DomainErrors;
using PSManagement.Domain.Identity.DomainErrors;
using PSManagement.Domain.Identity.Entities;
using PSManagement.Domain.Identity.Repositories;

using System;
using System.Threading.Tasks;

namespace PSManagement.Infrastructure.Services.Authentication
{
    public class AuthenticationService :IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUsersRepository _userRepository;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUsersRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<Result<AuthenticationResult>>  Login(String email, String password) {
            
            User u = await _userRepository.GetByEmail(email);
            if (u is null || u.HashedPassword != password) {
                return Result.Fail<AuthenticationResult>(UserErrors.InvalidLoginAttempt);

            }
            String token = _jwtTokenGenerator.GenerateToken(u);
            
            return  new AuthenticationResult {
                       Id = u.Id,
                       Email=u.Email,
                       FirstName="",
                       LastName ="",
                       Token=token};
        }
        public async Task<Result<AuthenticationResult>> Register(String email, String userName, String password) {
            // check if the user exist 
            var u = await _userRepository.GetByEmail(email);
            if (u is not null) {
                return Result.Fail(UserErrors.AlreadyUserExist);
            }
            var user = await _userRepository.AddAsync(
                new User{
                    Email=email ,
                    UserName=userName,
                    HashedPassword=password
                });
            // generate token 
            String token = _jwtTokenGenerator.GenerateToken(u);
            return Result.Ok<AuthenticationResult>(
            new AuthenticationResult
            {
                Id = user.Id,
                Email = email,
                FirstName = user.Employee?.PersonalInfo.FirstName,
                LastName = user.Employee?.PersonalInfo.LastName,
                Roles=user.Roles,
                Token = token
            });
            
        }


    }

}
