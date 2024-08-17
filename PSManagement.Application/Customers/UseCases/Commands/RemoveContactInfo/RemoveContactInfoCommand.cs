using Ardalis.Result;
using PSManagement.SharedKernel.CQRS.Command;

namespace PSManagement.Application.Customers.UseCases.Commands.RemoveContactInfo
{
    public record RemoveContactInfoCommand(
        int Id,
        int CustomerId) : ICommand<Result>;

}
