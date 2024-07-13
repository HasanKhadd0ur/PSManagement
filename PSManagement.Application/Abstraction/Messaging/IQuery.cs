using MediatR;

namespace PSManagement.Application.Abstraction.Messaging
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}
