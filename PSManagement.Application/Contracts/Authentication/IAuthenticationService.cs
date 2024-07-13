using System;
using System.Threading.Tasks;

namespace PSManagement.Application.Contracts.Authentication
{
    public interface IAuthenticationService
    {
        public Task<AuthenticationResult> Login(String email , String password);
        public Task<AuthenticationResult> Register(String email,String firstName ,String lastName, String password);


    }

}
