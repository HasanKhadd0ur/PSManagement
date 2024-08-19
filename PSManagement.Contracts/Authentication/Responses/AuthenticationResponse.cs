using PSManagement.Application.Contracts.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Contracts.Authentication
{
    public record AuthenticationResponse(
        int EmployeeId ,
        String FirstName,
        String LastName ,
        String Email ,
        ICollection<RoleDTO> Roles,
        String Token
        );
}
