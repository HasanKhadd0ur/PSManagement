using Ardalis.Result;
using PSManagement.Application.FinancialSpends.Common;
using PSManagement.Domain.Projects.Entities;
using PSManagement.Domain.Projects.Repositories;
using PSManagement.SharedKernel.CQRS.Command;
using PSManagement.SharedKernel.CQRS.Query;
using PSManagement.SharedKernel.ValueObjects;
using System;

namespace PSManagement.Application.FinancialSpends.UseCases.Queries.GetFinancialSpendingById
{
    public record GetFinancialSpendItemByIdQuery(
    int Id) : IQuery<Result<FinancialSpendingDTO>>;
}

