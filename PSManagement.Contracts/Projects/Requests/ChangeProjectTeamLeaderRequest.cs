namespace PSManagement.Contracts.Projects.Requests
{
    public record ChangeProjectTeamLeaderRequest(
    int EmployeeId,
    int ProjectId
    );

}
