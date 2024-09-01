using Microsoft.AspNetCore.Http;

namespace PSManagement.Contracts.Projects.Response
{
    public record FileAttachmentResponse(
    string AttachmentName,
    string AttachmentDescription,
    IFormFile File
    );

}
