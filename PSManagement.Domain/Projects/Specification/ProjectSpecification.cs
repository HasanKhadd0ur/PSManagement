using PSManagement.Domain.Projects.Entities;
using PSManagement.SharedKernel.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Domain.Projects
{
    public class ProjectSpecification : BaseSpecification<Project>
    {
        public ProjectSpecification(Expression<Func<Project, bool>> criteria = null) : base(criteria)
        {
            AddInclude(u => u.Steps);

        }
    }
}
