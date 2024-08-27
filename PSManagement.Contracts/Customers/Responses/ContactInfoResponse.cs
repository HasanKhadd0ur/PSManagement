using System;

namespace PSManagement.Contracts.Customers.Responses
{
    public class ContactInfoResponse {
        
        public int Id { get; set; }   
        public String ContactType { get; set; }
        public String ContactValue { get; set; }
    }
}
