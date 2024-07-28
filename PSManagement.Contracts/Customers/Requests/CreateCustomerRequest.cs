using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Contracts.Customers.Requests
{
    public record CreateCustomerRequest(
        String CustomerName, 
        AddressRecord Address ,
        String Email
        );

     public record AddressRecord(
        String StreetName ,
        int StreetNumber,
        int ZipCode ,
        String City
        );
}
