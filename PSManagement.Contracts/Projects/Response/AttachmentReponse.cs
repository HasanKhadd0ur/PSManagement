namespace PSManagement.Contracts.Projects.Response
{
    public record AttachmentReponse(
        int Id ,
        int ProjectId,
        string AttachmentUrl ,
        string AttachmentName ,
        string AttachmentDescription 
    );

}
