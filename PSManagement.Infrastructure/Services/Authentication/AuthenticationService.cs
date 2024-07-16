using PSManagement.Application.Contracts.Authentication;
using PSManagement.Application.Contracts.Authorization;
using PSManagement.SharedKernel.Utilities;
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
            if (u is null || u.Password != password) {
                return Result.Failure<AuthenticationResult>(new Error("404", "the password or email maybe wrong!."));

            }
            String token = _jwtTokenGenerator.GenerateToken(u.Id,u.FirstName,u.LastName,u.Email);
            
            return Result.Success<AuthenticationResult>(
                        new AuthenticationResult {
                        Id = u.Id,
                        Email=u.Email,
                        FirstName=u.FirstName,
                        LastName =u.LastName,
                        Token=token});
        }
        public async Task<Result<AuthenticationResult>> Register(String email, String firstName, String lastName, String password) {
            // check if the user exist 
            var u = await _userRepository.GetByEmail(email);
            if (u is not null) {
                return Result.Failure<AuthenticationResult>(new Error("404","the user already exist "));
            }
            await _userRepository.AddAsync(
                new User{
                    Email=email ,
                    FirstName=firstName,
                    LastName=lastName,
                    Password=password
                });
            // generate token 
            String token = _jwtTokenGenerator.GenerateToken(2322323,firstName,lastName,email);
            return Result.Success<AuthenticationResult>(
            new AuthenticationResult
            {
                Id = 233233,
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                Token = token
            });
            
        }


    }

}
