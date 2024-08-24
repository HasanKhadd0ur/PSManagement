namespace PSManagement.Contracts.Projects.Requests
{
    public record GetProjectsByProjectManagerRequest(
    int ProjectManagerId,
    int? PageNumber ,
    int? PageSize
    );
}
