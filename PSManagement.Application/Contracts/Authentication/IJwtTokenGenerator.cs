using System;

namespace PSManagement.Application.Contracts.Authentication
{
    public interface IJwtTokenGenerator
    {
        public String GenerateToken(Guid id , String firstName , String lastName,String email );
    }
}
