using Microsoft.Extensions.Logging;
using PSManagement.Application.Contracts.Providers;
using PSManagement.Domain.Customers.DomainEvents;
using PSManagement.Domain.Customers.Entities;
using PSManagement.SharedKernel.DomainEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Customers.Events
{
    public class CustomerCreatedEventHandler : IDomainEventHandler<CutsomerCreatedEvent>
    {
        private readonly ILogger<Customer> _logger;
        private readonly IDateTimeProvider _dateTimeProvider;

        public CustomerCreatedEventHandler(
            ILogger<Customer> logger,
            IDateTimeProvider dateTimeProvider)
        {
            _logger = logger;
            _dateTimeProvider = dateTimeProvider;
        }

        public  Task Handle(CutsomerCreatedEvent notification, CancellationToken cancellationToken)
        {

            _logger.LogInformation("new customer Added at "+_dateTimeProvider.UtcNow);

            return Task.CompletedTask;

        }
    }
}
