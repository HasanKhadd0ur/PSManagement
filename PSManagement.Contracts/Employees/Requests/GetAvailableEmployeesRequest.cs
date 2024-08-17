namespace PSManagement.Contracts.Employees.Requests
{
    public record GetAvailableEmployeesRequest(
    int? PageNumber,
    int? PageSize);
}
