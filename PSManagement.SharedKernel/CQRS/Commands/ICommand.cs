using MediatR;

namespace PSManagement.SharedKernel.CQRS.Command
{
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}
