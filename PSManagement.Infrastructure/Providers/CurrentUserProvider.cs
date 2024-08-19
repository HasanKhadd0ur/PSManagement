using Microsoft.AspNetCore.Http;
using PSManagement.Application.Contracts.Providers;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace PSManagement.Infrastructure.Services.Providers
{
    public class CurrentUserProvider : ICurrentUserProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int? EmployeeId
        {
            get
            {
                var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
                if (int.TryParse(userIdClaim, out var userId))
                {
                    return userId;
                }
                return null;
            }
        }
        public int? HiastId {
            get
            {
                var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirstValue("HiastId");
                if (int.TryParse(userIdClaim, out var hiastId))
                {
                    return hiastId;
                }
                return null;
            }
        }
        
        public IEnumerable<string> Roles => _httpContextAccessor.HttpContext?.User?.FindAll(ClaimTypes.Role)?.Select(r => r.Value) ?? Enumerable.Empty<string>();

        
        public string Email => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Email);

    }
}
