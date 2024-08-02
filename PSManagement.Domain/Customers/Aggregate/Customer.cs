﻿using PSManagement.Domain.Customers.DomainEvents;
using PSManagement.Domain.Customers.Entities;
using PSManagement.Domain.Customers.ValueObjects;
using PSManagement.SharedKernel.Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PSManagement.Domain.Customers.Aggregate
{
    public class Customer : IAggregateRoot
    {
        public String CustomerName { get; set; }
        public Address Address { get; set; }
        public String Email { get; set; }
        public ICollection<ContactInfo> ContactInfo { get; private set; }

        public Customer()
        {
                
        }

        public Customer(String customerName, Address address, string email)
        {
            CustomerName = customerName;
            Address = address;
            Email = email;
        }

        public void AddContactInfo(ContactInfo contactInfo)
        {
            if(ContactInfo is null)
            {
                ContactInfo = new List<ContactInfo>();
            }
            ContactInfo.Add(contactInfo);           

        }

    }
}
