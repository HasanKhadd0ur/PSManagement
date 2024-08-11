using PSManagement.Domain.Identity.Entities;
using System;

namespace PSManagement.Application.Contracts.Tokens
{
    public interface IJwtTokenGenerator
    {
        public string GenerateToken(User user);
    }
}
