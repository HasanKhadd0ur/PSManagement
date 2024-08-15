using Ardalis.Result;
using PSManagement.Application.FinancialSpends.Common;
using PSManagement.Domain.Projects.Entities;
using PSManagement.SharedKernel.CQRS.Query;
using System.Collections.Generic;

namespace PSManagement.Application.FinancialSpends.UseCases.Queries.GetFinancialSpendingByProject
{
    public record GetFinancialSpendItemByProjectQuery(
       int ProjectId,
       int? PageNumber,
       int? PageSize) : IQuery<Result<IEnumerable<FinancialSpendingDTO>>>;
}

