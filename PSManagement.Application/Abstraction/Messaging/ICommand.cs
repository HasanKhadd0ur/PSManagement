using MediatR;

namespace PSManagement.Application.Abstraction.Messaging
{
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}
