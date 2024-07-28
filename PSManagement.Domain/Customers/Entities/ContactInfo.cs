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
        public String ConatctValue { get; private set; }

        public ContactInfo(string conatctValue, string contactType)
        {
            ConatctValue = conatctValue;
            ContactType = contactType;
        }

        public ContactInfo()
        {

        }

    }
}
