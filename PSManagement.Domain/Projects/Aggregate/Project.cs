using PSManagement.Domain.Customers.Aggregate;
using PSManagement.Domain.Employees.Entities;
using PSManagement.Domain.Projects.Entities;
using PSManagement.Domain.ProjectTypes.Entities;
using PSManagement.Domain.Steps.Entities;
using PSManagement.Domain.Tracking;
using PSManagement.SharedKernel.Aggregate;
using PSManagement.SharedKernel.ValueObjects;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Domain.Projects.Aggregate
{
    public class Project : IAggregateRoot
    {
        // information about the project itself 
        public ProposalInfo ProposalInfo { get; set; }
        public ProjectInfo ProjectInfo { get; set; }
        //public ProjectType ProjectType { get; set; }
        public ProjectStatus ProjectStatus { get; set; }
        public Aggreement ProjectAggreement { get; set; }

        // information about who lead and execute the project 
        public int TeamLeaderId { get; set; }
        public Employee TeamLeader { get; set; }
        public int ProjectManagerId { get; set; }
        public Employee ProjectManager { get; set; }

        public Department Executer { get; set; }
        
        // the proposer of the project 
        public Customer Proposer { get; set; }

        // 
        public ICollection<Step> Steps { get; set; }
        public ICollection<Employee> Participants { get; set;  }
        public ICollection<Attachment> Attachments { get; set; }

        // finincial plan 
        public FinincialFund FinincialFund { get; set; }


        public ICollection<EmployeeParticipate> EmployeeParticipates { get; set; }
        public ICollection<Track> Tracks { get; set; }
        
        public Project()
        {

        }
    }
    public record FinincialFund (
        string FinicialStatus,
        string Source 
        );
}
