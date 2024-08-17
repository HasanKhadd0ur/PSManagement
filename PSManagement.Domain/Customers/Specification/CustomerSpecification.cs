using PSManagement.Domain.Customers.Entities;
using PSManagement.SharedKernel.Specification;
using System;
using System.Linq.Expressions;

namespace PSManagement.Domain.Customers.Specification
{
    public class CustomerSpecification : BaseSpecification<Customer>
    {
        public CustomerSpecification(Expression<Func<Customer, bool>> criteria = null) : base(criteria)
        {

            AddInclude(e => e.ContactInfo);
        }
    }
}
