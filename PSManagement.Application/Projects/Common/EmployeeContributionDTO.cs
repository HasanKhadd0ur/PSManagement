using PSManagement.Application.Employees.Common;
using PSManagement.Domain.Employees.Entities;

namespace PSManagement.Application.Projects.Common
{
    public class EmployeeContributionDTO {
       public int ContributionRatio { get; set; }
       public EmployeeDTO Employee { get; set; }

        public EmployeeContributionDTO(int contributionRatio, EmployeeDTO employee)
        {
            ContributionRatio = contributionRatio;
            Employee = employee;
        }
    }
}
