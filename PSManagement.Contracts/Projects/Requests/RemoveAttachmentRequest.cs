namespace PSManagement.Contracts.Projects.Requests
{
    public record RemoveAttachmentRequest(
        int ProjectId,
        int AttachmentId   
     );

}
