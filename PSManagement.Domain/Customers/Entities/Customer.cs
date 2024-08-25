using PSManagement.Domain.Customers.DomainEvents;
using PSManagement.Domain.Customers.ValueObjects;
using PSManagement.Domain.Projects.Entities;
using PSManagement.SharedKernel.Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PSManagement.Domain.Customers.Entities
{
    public class Customer : IAggregateRoot
    {
        public string CustomerName { get; set; }
        public Address Address { get; set; }
        public string Email { get; set; }

        #region Association 
        public ICollection<ContactInfo> ContactInfo { get; private set; }
        public ICollection<Project> Projects { get; private set; }
        #endregion Association 

        #region Encapsulation
        public void AddContactInfo(ContactInfo contactInfo)
        {
            if (ContactInfo is null)
            {
                ContactInfo = new List<ContactInfo>();
            }
            ContactInfo.Add(contactInfo);

        }

        #endregion Encapsulation

        #region Constructors
        public Customer()
        {

        }

        public Customer(string customerName, Address address, string email)
        {
            CustomerName = customerName;
            Address = address;
            Email = email;
        }

        #endregion Construtors


    }
}
