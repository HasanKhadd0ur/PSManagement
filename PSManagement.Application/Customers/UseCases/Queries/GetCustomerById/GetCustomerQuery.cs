using Ardalis.Result;
using PSManagement.Application.Customers.Common;
using PSManagement.SharedKernel.CQRS.Query;
using System;
using System.Linq;
using System.Text;

namespace PSManagement.Application.Customers.UseCases.Queries.GetCustomer
{
    public record  GetCustomerQuery(int customerId) : IQuery<Result<CustomerDTO>>;

}
