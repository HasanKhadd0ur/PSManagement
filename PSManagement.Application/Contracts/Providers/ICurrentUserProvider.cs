using PSManagement.Application.Contracts.Authentication;
using System.Collections.Generic;

namespace PSManagement.Application.Contracts.Providers
{
    public interface ICurrentUserProvider
    {
        int? EmployeeId { get; }
        string Email { get; }
        int? HiastId { get; }
        IEnumerable<string> Roles { get; }
    }
}
