using PSManagement.Domain.Projects.Entities;
using PSManagement.SharedKernel.Specification;
using System;
using System.Linq.Expressions;

namespace PSManagement.Domain.Projects
{
    public class EmployeeParticipateSpecification : BaseSpecification<EmployeeParticipate>
    {
        public EmployeeParticipateSpecification(Expression<Func<EmployeeParticipate, bool>> criteria = null) : base(criteria)
        {
            AddInclude(u => u.Employee);

        }
    }
}
