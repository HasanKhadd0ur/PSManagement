using MediatR;

namespace PSManagement.SharedKernel.CQRS.Command
{
    public interface ILoggableCommand<out TResponse> : ICommand<TResponse>
    {
    }
}
