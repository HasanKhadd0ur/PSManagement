using PSManagement.Domain.Projects.Entities;
using PSManagement.SharedKernel.Specification;
using System;
using System.Linq.Expressions;

namespace PSManagement.Domain.Projects
{
    public class StepSpecification : BaseSpecification<Step>
    {
        public StepSpecification(Expression<Func<Step, bool>> criteria = null) : base(criteria)
        {
        }
    }
}
