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
        public String  ContactType { get; private set; }
        public String ContactValue { get; private set; }

        public ContactInfo(string contactValue, string contactType)
        {
            ContactValue = contactValue;
            ContactType = contactType;
        }

        public ContactInfo()
        {
            
        }

    }
}
