namespace PSManagement.Contracts.Employees.Requests
{
    public record GetEmployeeParticipationRequest(
        int EmployeeId,
        int? PageNumber,
        int? PageSize);
}
