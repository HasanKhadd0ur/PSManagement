using Ardalis.Result;
using PSManagement.Application.Projects.Common;
using PSManagement.SharedKernel.CQRS.Query;
using System.Collections.Generic;

namespace PSManagement.Application.Projects.UseCases.Queries.GetParticipants
{
    public record GetProjectParticipantsQuery(
        int ProjectId
        ) : IQuery<Result<IEnumerable<EmployeeParticipateDTO>>>;

}
