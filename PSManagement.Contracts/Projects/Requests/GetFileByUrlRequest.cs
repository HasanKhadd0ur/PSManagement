namespace PSManagement.Contracts.Projects.Requests
{
    public record GetFileByUrlRequest(
        string FileUrl,
        int AttachmentId
        );

}
