using Microsoft.AspNetCore.Http;

namespace PSManagement.Application.Projects.Common
{
    public record FileAttachmentDTO(
        string AttachmentName,
        string AttachmentDescription,
        IFormFile File
        );
}
