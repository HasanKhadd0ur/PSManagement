using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PSManagement.Domain.Identity.Entities;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;
using System.Linq;

using System.Security.Claims;
using System.Text;
using System.Collections.Generic;
using PSManagement.Application.Contracts.Providers;
using PSManagement.Application.Contracts.Tokens;
using PSManagement.Infrastructure.Settings;

namespace PSManagement.Infrastructure.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly JwtSetting _jwtSetting;
        public JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSetting> jwtOptions)
        {
            _dateTimeProvider = dateTimeProvider;
            _jwtSetting = jwtOptions.Value;
        }

        public string GenerateToken(User user)
        {
            var signingCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSetting.Secret)),
                    SecurityAlgorithms.HmacSha256
                );
            List<Claim> claims = new List<Claim>{
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email)
            };

            foreach (Role role  in user.Roles) {
                claims.Add(new Claim(ClaimTypes.Role, role.Name));
            }
            var securityToken = new JwtSecurityToken(
                issuer: _jwtSetting.Issuer,
                audience:_jwtSetting.Audience,
                expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSetting.ExpireMinutes),
                claims : claims,
                signingCredentials:signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
