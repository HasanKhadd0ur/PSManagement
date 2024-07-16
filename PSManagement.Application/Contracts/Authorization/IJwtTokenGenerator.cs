using System;

namespace PSManagement.Application.Contracts.Authorization
{
    public interface IJwtTokenGenerator
    {
        public String GenerateToken(int id , String firstName , String lastName,String email );
    }
}
