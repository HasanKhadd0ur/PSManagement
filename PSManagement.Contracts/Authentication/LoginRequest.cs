using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Contracts.Authentication
{
    public record LoginRequest(
        String Email ,
        String PassWorrd
        );
}
