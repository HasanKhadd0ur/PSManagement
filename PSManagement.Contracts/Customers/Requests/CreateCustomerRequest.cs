using PSManagement.Domain.Customers.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Contracts.Customers.Requests
{
    public record CreateCustomerRequest(
        String CustomerName, 
        Address Address ,
        String Email
        );

}
