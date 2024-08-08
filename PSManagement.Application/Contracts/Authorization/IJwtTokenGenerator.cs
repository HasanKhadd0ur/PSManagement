using PSManagement.Domain.Identity.Entities;
using System;

namespace PSManagement.Application.Contracts.Authorization
{
    public interface IJwtTokenGenerator
    {
        public String GenerateToken(User user);
    }
}
