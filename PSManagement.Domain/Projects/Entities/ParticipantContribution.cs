using PSManagement.Domain.Employees.Entities;

namespace PSManagement.Domain.Projects.Entities
{
    public class ParticipantContribution { 

        public int ContributionRatio { get; set; }
        public Employee Employee { get; set; }

        public ParticipantContribution(int contributionRatio, Employee employee)
        {
            ContributionRatio = contributionRatio;
            Employee = employee;
        }   
    }
}
