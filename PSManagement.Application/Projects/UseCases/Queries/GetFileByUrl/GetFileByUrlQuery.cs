using Ardalis.Result;
using PSManagement.Application.Projects.Common;
using PSManagement.SharedKernel.CQRS.Query;

namespace PSManagement.Application.Projects.UseCases.Queries.GetFileByUrl
{
    public record GetFileByUrlQuery(
        string FileUrl,
        int AttachmentId
        ) : IQuery<Result<FileAttachmentDTO>>;

}
