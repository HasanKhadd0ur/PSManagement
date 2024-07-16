using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PSManagement.Application.Common.Services;
using PSManagement.Application.Contracts.Authorization;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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

        public string GenerateToken(int  id, string firstName, string lastName, string email)
        {
            var signingCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSetting.Secret)),
                    SecurityAlgorithms.HmacSha256   
                );
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub,id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email,email),
                new Claim(JwtRegisteredClaimNames.GivenName,firstName),
                new Claim(JwtRegisteredClaimNames.FamilyName,lastName)


            };

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
