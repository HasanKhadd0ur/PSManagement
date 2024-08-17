using PSManagement.Contracts.Customers.Requests;
using PSManagement.Domain.Customers.ValueObjects;
using System;
using System.Collections.Generic;

namespace PSManagement.Contracts.Customers.Responses
{
    public class CustomerResponse {
        public CustomerResponse()
        {

        }

        public int Id { get; set; }
        public String CustomerName { get; set; }
        public String Email { get; set; }
        public Address Address { get; set; }
        public IEnumerable<ContactInfoResponse> ContactInfo { get; set; }
    }
}
