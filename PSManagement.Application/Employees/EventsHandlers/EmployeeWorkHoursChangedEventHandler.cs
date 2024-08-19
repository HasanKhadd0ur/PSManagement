using PSManagement.Domain.Employees.DomainEvents;
using PSManagement.SharedKernel.DomainEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Employees.EventsHandlers
{
    public class EmployeeWorkHoursChangedEventHandler : IDomainEventHandler<EmployeeWorkHoursChangedEvent>
    {
        public Task Handle(EmployeeWorkHoursChangedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;

        }
    }
}
