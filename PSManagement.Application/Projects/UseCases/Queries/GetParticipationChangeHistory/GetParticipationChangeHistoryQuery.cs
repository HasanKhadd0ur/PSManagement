using Ardalis.Result;
using PSManagement.Application.Projects.Common;
using PSManagement.SharedKernel.CQRS.Query;
using PSManagement.SharedKernel.Specification;
using System.Collections.Generic;

namespace PSManagement.Application.Projects.UseCases.Queries.GetParticipationChangeHistory
{
    public record GetParticipationChangeHistoryQuery(
        int ProjectId
        ) : IQuery<Result<IEnumerable<ParticipationChangeDTO>>>;

}
