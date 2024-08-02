using PSManagement.Domain.Steps.Aggregate;
using PSManagement.SharedKernel.Entities;
using System.Collections.Generic;

namespace PSManagement.Domain.Tracking.Entities
{
    public class StepTrack : BaseEntity
    {
        public Step Step { get; set; }
        public IEnumerable<EmployeeTrack> EmployeeTracks { get; set; }
        public StepTrack()
        {
                
        }
    }
}
