using PSManagement.SharedKernel.Aggregate;
using PSManagement.SharedKernel.Entities;
using System;

namespace PSManagement.Domain.Identity.Aggregate
{
    public class User : IAggregateRoot
    {
        public string Email { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string HashedPassword { get; set; }

    }
}