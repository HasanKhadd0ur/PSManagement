using PSManagement.Domain.Employees.Entities;
using PSManagement.SharedKernel.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Domain.Employees.Specification
{
    public class EmployeesSpecification : BaseSpecification<Employee>
    {
        public EmployeesSpecification(Expression<Func<Employee, bool>> criteria=null) : base(criteria)
        {
          
            AddInclude(e => e.User);
        }
    }
}
