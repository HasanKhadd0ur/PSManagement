
using FluentResults;
using System;
using System.Threading.Tasks;

namespace PSManagement.Application.Contracts.Authentication
{
    public interface IAuthenticationService
    {
        public Task<Result<AuthenticationResult>> Login(String email , String password);
        public Task<Result<AuthenticationResult>> Register(String email,String firstName ,String lastName, String password);


    }

}
