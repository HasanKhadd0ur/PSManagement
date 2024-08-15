using Ardalis.Result;
using PSManagement.SharedKernel.CQRS.Command;

namespace PSManagement.Application.FinancialSpends.UseCases.Commands.RemoveFinancialSpendingItem
{
    public record RemoveFinancialSpendItemCommand(
        int ProjectId,
        int Id
        ) : ICommand<Result>;

}
