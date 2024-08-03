using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PSManagement.Domain.Identity.Entities
{
    public class Role  {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
        public ICollection<Permission> Permissions { get; set; }
        public ICollection<User> Users { get; set; }

    }


}