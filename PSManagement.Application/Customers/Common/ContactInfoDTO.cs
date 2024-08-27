using PSManagement.Domain.Customers.ValueObjects;
using System;

namespace PSManagement.Application.Customers.Common
{
    public class ContactInfoDTO
    {

        public int Id { get; set; }   
        public String ContactValue { get; set; }
        public String ContactType { get; set; }

    }
}