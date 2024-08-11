using Ardalis.Result;
using PSManagement.Application.Customers.Common;
using PSManagement.SharedKernel.CQRS.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Application.Customers.UseCases.Queries.ListAllCustomers
{
    public record ListAllCustomersQuery() : IQuery<Result<IEnumerable<CustomerDTO>>>;

}
