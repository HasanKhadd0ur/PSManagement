using PSManagement.Domain.Departments.Aggregate;
using PSManagement.Domain.Employees.Aggregate;
using PSManagement.Domain.Steps.Aggregate;
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
        public Aggreement ProjectAggreement { get; set; }    
        public ICollection<Employee> Participants { get; set;  }
        public ICollection<Step> Steps { get; set; }
        public Employee TeamLeader { get; set; }
        public Department Executer { get; set; }
        public Employee Proposer { get; set; }

        public Project()
        {

        }
    }

}
