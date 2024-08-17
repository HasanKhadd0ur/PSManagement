using PSManagement.SharedKernel.Specification;
using System;
using System.Linq.Expressions;

namespace PSManagement.Domain.Tracking.Specification
{
    public class EmployeeTrackSpecification : BaseSpecification<EmployeeTrack>
    {
        public EmployeeTrackSpecification(Expression<Func<EmployeeTrack, bool>> criteria = null) : base(criteria)
        {


        }
    }
}
