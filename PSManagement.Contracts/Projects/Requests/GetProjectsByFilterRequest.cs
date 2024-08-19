namespace PSManagement.Contracts.Projects.Requests
{
    public record GetProjectsByFilterRequest(
     string ProjectName,
     string TeamLeaderName,
     string DepartmentName,
     string ProposerName,
     int? ProjectManagerId,
     int? TeamLeaderId,
     int? PageNumber,
     int? PageSize);
}
