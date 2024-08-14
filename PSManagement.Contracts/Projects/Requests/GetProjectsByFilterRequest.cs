namespace PSManagement.Contracts.Projects.Requests
{
    public record GetProjectsByFilterRequest(
     string ProjectName,
     string TeamLeaderName,
     string DepartmentName,
     string ProposerName
 );

}
