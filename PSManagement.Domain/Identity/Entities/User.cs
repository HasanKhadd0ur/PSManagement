using PSManagement.Domain.Employees.Entities;
using PSManagement.SharedKernel.Aggregate;
using PSManagement.SharedKernel.Entities;
using System.Collections.Generic;

namespace PSManagement.Domain.Identity.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public Employee Employee { get; set; }
        public string HashedPassword { get; set; }
        public ICollection<Role> Roles { get; set; }

    }


}