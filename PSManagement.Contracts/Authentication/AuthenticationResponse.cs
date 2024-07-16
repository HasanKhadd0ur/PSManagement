using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Contracts.Authentication
{
    public record AuthenticationResponse(
        int Id ,
        String FirstName,
        String LastName ,
        String Email ,
        String Token
        );
}
