using PSManagement.Domain.Employees.Entities;
using PSManagement.Domain.Projects.Aggregate;
using PSManagement.Domain.Tracking;
using PSManagement.Domain.Tracking.Entities;
using PSManagement.SharedKernel.Aggregate;
using PSManagement.SharedKernel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Domain.Steps.Entities
{
    public class Step : BaseEntity
    {
        public string StepName { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public DateTime StartDate { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public ICollection<Item> Purchases { get; set; }

        public ICollection<Employee> Participants { get; set; }
        public ICollection<StepTrack> StepTracks { get; set; }

        public Step()
        {

        }
    }

}
