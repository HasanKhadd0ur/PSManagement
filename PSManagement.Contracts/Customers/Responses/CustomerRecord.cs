using PSManagement.Contracts.Customers.Requests;
using System;
using System.Collections.Generic;

namespace PSManagement.Contracts.Customers.Responses
{
    public class CustomerRecord {
        public CustomerRecord()
        {

        }

        public int Id { get; set; }
        public String CustomerName { get; set; }
        public String Email { get; set; }
        public AddressRecord Address { get; set; }
        public IEnumerable<ContactInfoRecord> ContactInfo { get; set; }
    }
}
