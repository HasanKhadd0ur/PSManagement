using Ardalis.Result;
using PSManagement.Application.Projects.Common;
using PSManagement.SharedKernel.CQRS.Query;
using PSManagement.SharedKernel.Specification;
using System.Collections.Generic;

namespace PSManagement.Application.Projects.UseCases.Queries.GetProjectAttachments
{
    public record GetProjectAttachmentsQuery(
        int ProjectId,
        int? PageNumber,
        int? PageSize

        ) : IQuery<Result<IEnumerable<AttachmentDTO>>>;
}
