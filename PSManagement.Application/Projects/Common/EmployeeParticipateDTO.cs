using PSManagement.Application.Employees.Common;
using PSManagement.Domain.Projects.ValueObjects;

namespace PSManagement.Application.Projects.Common
{
    public class EmployeeParticipateDTO
    {
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
        public ProjectInfo ProjectInfo { get; set; }
        public EmployeeDTO Employee { get; set; }
        public int PartialTimeRatio { get; set; }
        public string Role { get; set; }
    }

}