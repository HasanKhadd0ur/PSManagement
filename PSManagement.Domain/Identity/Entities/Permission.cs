using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PSManagement.Domain.Identity.Entities
{
    public class Permission
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
        public ICollection<Role> Roles { get; set; }
    }


}