using Ardalis.Result;
using PSManagement.Application.Projects.Common;
using PSManagement.SharedKernel.CQRS.Command;
using PSManagement.SharedKernel.CQRS.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace PSManagement.Application.Projects.UseCases.Queries.GetCompletionContribution
{
    public record GetCompletionContributionQuery(
        int ProjectId) : IQuery<Result<IEnumerable<EmployeeContributionDTO>>>;

}
