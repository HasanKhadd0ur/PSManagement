using PSManagement.SharedKernel.Entities;
using System;

namespace PSManagement.Application.Contracts.Authentication
{
    public class User :BaseEntity
    {
        public String Email { get; set; }
        public String LastName { get; set; }
        public String FirstName { get; set; }
        public String Password { get; set; }
        public String Token { get; set; }

    }
}