using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using PSManagement.SharedKernel.CQRS.Command;
using PSManagement.SharedKernel.CQRS.Query;

namespace PSManagement.Application.Behaviors.LoggingBehavior
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : ILoggableCommand<TResponse> 
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var requestName = typeof(TRequest).Name;
            _logger.LogInformation("Starting request: {RequestName} at {DateTime}", requestName, DateTime.UtcNow);

            try
            {
                var response = await next();
                _logger.LogInformation("Completed request: {RequestName} at {DateTime}", requestName, DateTime.UtcNow);
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Request {RequestName} failed at {DateTime}", requestName, DateTime.UtcNow);
                throw;
            }
        }


    }
}
