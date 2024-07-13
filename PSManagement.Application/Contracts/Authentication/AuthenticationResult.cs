using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Application.Contracts.Authentication
{
    public class AuthenticationResult
    {
        public Guid Id { get; set; }
        public String Email { get; set; }
        public String LastName { get; set; }
        public String FirstName { get; set; }
        public String Token { get; set; }

    }
}
