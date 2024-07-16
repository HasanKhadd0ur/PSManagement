using MediatR;

namespace PSManagement.SharedKernel.CQRS.Command
{
    public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
                         where TCommand : ICommand<TResponse>
    {
    }
}
