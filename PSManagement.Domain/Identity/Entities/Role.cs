using PSManagement.SharedKernel.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PSManagement.Domain.Identity.Entities
{
    public class Role :BaseEntity {
        public String Name { get; set; }
        public ICollection<Permission> Permissions { get; set; }
        public ICollection<User> Users { get; set; }

    }


}