using PSManagement.Domain.Customers.ValueObjects;
using PSManagement.SharedKernel.Entities;
using PSManagement.SharedKernel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PSManagement.Domain.Customers.Entities
{
    public sealed class ContactInfo : BaseEntity
    {
        public ContactNumber PhoneNumber { get; set; }
        public ContactNumber MobileNumber { get; set; }
        public String Email { get; set; }

        public ContactInfo()
        {

        }
        public ContactInfo(string email, ContactNumber mobileNumber, ContactNumber phoneNumer)
        {
            Email = email;
            MobileNumber = mobileNumber;
            PhoneNumber = phoneNumer;
        }

        
    }
}
