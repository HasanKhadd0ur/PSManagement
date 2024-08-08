using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Contracts.Customers.Requests
{
    public record  AddContactInfoRequest(
        int CustomerId,
        String ContactType,
        String ContactValue);
}
