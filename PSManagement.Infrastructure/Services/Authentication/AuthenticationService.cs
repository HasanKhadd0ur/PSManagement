using PSManagement.Application.Contracts.Authentication;
using System;
using System.Threading.Tasks;

namespace PSManagement.Infrastructure.Services.Authentication
{
    public class AuthenticationService :IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<AuthenticationResult>  Login(String email, String password) {

            return new AuthenticationResult {
                Id = Guid.NewGuid(),
                Email=email,
                FirstName="First  name ",
                LastName ="last Name ",
                Token="token"

            };
        }
        public async Task<AuthenticationResult> Register(String email, String firstName, String lastName, String password) {
            // check if the user exist 

            Guid userId = Guid.NewGuid();
            // generate token 
            String token = _jwtTokenGenerator.GenerateToken(userId,firstName,lastName,email);
            return new AuthenticationResult
            {
                Id = Guid.NewGuid(),
                Email = email,
                FirstName =firstName,
                LastName =lastName,
                Token=token
            };
        }


    }

}
