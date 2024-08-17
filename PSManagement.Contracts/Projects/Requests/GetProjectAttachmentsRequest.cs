namespace PSManagement.Contracts.Projects.Requests
{
    public record GetProjectAttachmentsRequest(
       int ProjectId,
       int? PageNumber,
       int? PageSize

       );
}
