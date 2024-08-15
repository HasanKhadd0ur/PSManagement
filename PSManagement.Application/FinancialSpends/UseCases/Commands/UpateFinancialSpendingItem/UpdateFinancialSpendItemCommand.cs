using Ardalis.Result;
using PSManagement.SharedKernel.CQRS.Command;
using PSManagement.SharedKernel.ValueObjects;
using System;

namespace PSManagement.Application.FinancialSpends.UseCases.Commands.UpateFinancialSpendingItem
{
    public record UpdateFinancialSpendItemCommand(
        int ProjectId,
        int Id,
        Money ExternalPurchase,
        int LocalPurchase,
        string CostType,
        string Description,
        DateTime ExpectedSpendingDate
    ) : ICommand<Result>;
}

