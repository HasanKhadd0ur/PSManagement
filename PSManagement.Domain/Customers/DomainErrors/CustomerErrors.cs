using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Domain.Customers.DomainErrors
{
    public static class CustomerErrors 
    {
        public static Error InvalidEntryError { get;  } = new Error("Customer Invalid Entry Erorr.");  
    }
}
