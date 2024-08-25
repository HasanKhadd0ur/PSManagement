using PSManagement.Domain.Projects.Entities;
using PSManagement.SharedKernel.Specification;
using System;
using System.Linq.Expressions;

namespace PSManagement.Domain.Projects
{
    public class ProjectTypeSpecification : BaseSpecification<ProjectType>
    {
        public ProjectTypeSpecification(Expression<Func<ProjectType, bool>> criteria = null) : base(criteria)
        {
            AddInclude(u => u.Projects);

        }
    }
}
