using PSManagement.Domain.Customers.Aggregate;
using PSManagement.Domain.Employees.Entities;
using PSManagement.Domain.Projects.Entities;
using PSManagement.Domain.ProjectTypes.Entities;
using PSManagement.Domain.Steps.Entities;
using PSManagement.Domain.Tracking;
using PSManagement.SharedKernel.Aggregate;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Domain.Projects.Aggregate
{
    public class Project : IAggregateRoot
    {
        public ProposalInfo ProposalInfo { get; set; }
        public ProjectInfo ProjectInfo { get; set; }
        public ProjectType ProjectType { get; set; }
        public ProjectStatus ProjectStatus { get; set; }
        public Aggreement ProjectAggreement { get; set; }
        public Employee TeamLeader { get; set; }
        public Department Executer { get; set; }
        public Customer Proposer { get; set; }

        public ICollection<Employee> Participants { get; set;  }
        public ICollection<Step> Steps { get; set; }
        public ICollection<Track> Tracks { get; set; }
        public ICollection<Attachment> Attachments { get; set; }

        public Project()
        {

        }
    }
}
