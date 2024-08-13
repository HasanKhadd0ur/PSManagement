using PSManagement.Application.Employees.Common;

namespace PSManagement.Application.Projects.Common
{
    public class EmployeeParticipateDTO
    {
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
        public EmployeeDTO Employee { get; set; }
        public int PartialTimeRatio { get; set; }
        public string Role { get; set; }
    }
}