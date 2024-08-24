using PSManagement.Application.Employees.Common;
using PSManagement.Domain.Projects.ValueObjects;

namespace PSManagement.Contracts.Projects.Response
{
    public class EmployeeParticipateResponse
    {
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
        public ProjectInfo ProjectInfo { get; set; }
        
        public EmployeeResponse Employee { get; set; }
        public int PartialTimeRatio { get; set; }
        public string Role { get; set; }
    }
}