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
    /// <summary>
    /// the class represent the contact info item for the customer
    /// </summary>
    public sealed class ContactInfo : BaseEntity
    {
        // the key for contact 
        public String  ContactType { get; private set; }
        
        //the value for contact
        public String ContactValue { get; private set; }

        #region Constructors
        public ContactInfo(string contactValue, string contactType)
        {
            ContactValue = contactValue;
            ContactType = contactType;
        }

        public ContactInfo()
        {
            
        }
        #endregion Constructors
    }
}
