namespace PSManagement.Contracts.Employees.Requests
{
    public record GetEmployeesByFilterRequest(
     string EmployeeFirstName,
     int? HiastId,
     string DepartmentName,
     string WorkType
     ) ;
}
