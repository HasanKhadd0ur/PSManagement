using PSManagement.Domain.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Application.Contracts.Authentication
{
    public class AuthenticationResult
    {
        public int EmployeeId { get; set; }
        public String Email { get; set; }
        public String LastName { get; set; }
        public String FirstName { get; set; }
        public ICollection<RoleDTO> Roles { get; set; }
        public String Token { get; set; }

    }

    public class RoleDTO{
        public String Name { get; set; }
        public int Id { get; set; }

    }


}
