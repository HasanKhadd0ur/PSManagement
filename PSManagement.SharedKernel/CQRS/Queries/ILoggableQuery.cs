namespace PSManagement.SharedKernel.CQRS.Query
{
    public interface ILoggableQuery<out TResponse> : IQuery<TResponse>
    {
    }

}
