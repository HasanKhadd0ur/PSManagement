using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Contracts.Customers.Requests
{
    public record  UpdateCustomerRequest(
        int CustomerId,
        String CustomerName,
        AddressRecord Address,
        String Email);
}
