namespace PSManagement.Contracts.Projects.Requests
{
    public record GetProjectsByProjectManagerRequest(
    int ProjectManager,
    int? PageNumber ,
    int? PageSize
    );
}
