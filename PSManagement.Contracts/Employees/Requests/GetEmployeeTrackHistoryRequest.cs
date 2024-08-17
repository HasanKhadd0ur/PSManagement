namespace PSManagement.Contracts.Employees.Requests
{
    public record GetEmployeeTrackHistoryRequest(
        int EmployeeId,
        int ProjectId,
        int? PageNumber,
        int? PageSize
    );
}
