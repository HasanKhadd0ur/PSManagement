using PSManagement.Domain.Tracking;
using PSManagement.SharedKernel.Specification;
using System;
using System.Linq.Expressions;

namespace PSManagement.Domain.Tracking.Specification
{
    public class TrackSpecification : BaseSpecification<Track>
    {
        public TrackSpecification(Expression<Func<Track, bool>> criteria = null) : base(criteria)
        {


        }
    }

}
