using MediatR;

namespace PSManagement.SharedKernel.CQRS.Query
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}
