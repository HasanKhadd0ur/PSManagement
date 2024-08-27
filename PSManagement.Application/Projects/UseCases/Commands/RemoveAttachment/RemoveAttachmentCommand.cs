using Ardalis.Result;
using PSManagement.SharedKernel.CQRS.Command;
using System.Linq;

namespace PSManagement.Application.Projects.UseCases.Commands.RemoveAttachment
{
    public record RemoveAttachmentCommand(
        int ProjectId,
        int AttachmentId
        ) : ILoggableCommand<Result>;

}
