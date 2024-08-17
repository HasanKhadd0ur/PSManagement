using PSManagement.Domain.Tracking.Entities;
using PSManagement.SharedKernel.Specification;
using System;
using System.Linq.Expressions;

namespace PSManagement.Domain.Tracking.Specification
{
    public class StepTrackSpecification : BaseSpecification<StepTrack>
    {
        public StepTrackSpecification(Expression<Func<StepTrack, bool>> criteria = null) : base(criteria)
        {


        }
    }
}
