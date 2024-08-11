using PSManagement.Domain.Identity.Entities;
using PSManagement.SharedKernel.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Domain.Identity.Specification
{
    public class UserSpecification : BaseSpecification<User>
    {
        public  UserSpecification(Expression<Func<User, bool>> criteria = null) : base(criteria)
        {
            AddInclude(u => u.Roles);
            AddInclude(u => u.Employee);

        }
    }
}
