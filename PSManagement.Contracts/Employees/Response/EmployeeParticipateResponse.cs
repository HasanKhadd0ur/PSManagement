using PSManagement.Application.Employees.Common;

namespace PSManagement.Contracts.Projects.Response
{
    public class EmployeeParticipateResponse
    {
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
        public EmployeeResponse Employee { get; set; }
        public int PartialTimeRatio { get; set; }
        public string Role { get; set; }
    }
}