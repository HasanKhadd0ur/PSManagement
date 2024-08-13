namespace PSManagement.Contracts.Projects.Requests
{
    public record CancelProjectRequest(
        int EmployeeId,
        int ProjectId
     );

}
