using Ardalis.Result;
using PSManagement.SharedKernel.CQRS.Command;
using PSManagement.SharedKernel.ValueObjects;
using System;

namespace PSManagement.Application.FinancialSpends.UseCases.Commands.CreateFinancialSpendItem
{
    public record CreateFinancialSpendItemCommand(
    int ProjectId,
    Money ExternalPurchase,
    int LocalPurchase,
    string CostType,
    string Description,
    DateTime ExpectedSpendingDate
    ) : ICommand<Result<int>>;
}
