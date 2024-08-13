using Microsoft.AspNetCore.Http;
using System;

namespace PSManagement.Contracts.Projects.Requests
{
    public record AddAttachmentRequest(
        int ProjectId,
        String AttachmentDescription,
        String AttachmentName,
        IFormFile File);

}
