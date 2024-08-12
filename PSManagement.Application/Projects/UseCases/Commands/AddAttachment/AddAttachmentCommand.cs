using Ardalis.Result;
using Microsoft.AspNetCore.Http;
using PSManagement.SharedKernel.CQRS.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Application.Projects.UseCases.Commands.AddAttachment
{
    public  record AddAttachmentCommand(
        int ProjectId, 
        String AttachmentDescription,
        String AttachmentName,
        IFormFile File        ) : ICommand<Result<int>>;
}
