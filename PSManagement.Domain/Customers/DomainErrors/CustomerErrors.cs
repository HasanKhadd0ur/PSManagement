using ErrorOr;
using PSManagement.SharedKernel.DomainErrors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Domain.Customers.DomainErrors
{
    public static class CustomerErrors 
    {
        public static DomainError InvalidEntryError { get;  } = new ("Customer.InvalidEntry.","Invalid Customer Data");  
    }
}
