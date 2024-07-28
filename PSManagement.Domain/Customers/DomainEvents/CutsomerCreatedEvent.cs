using PSManagement.SharedKernel.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Domain.Customers.DomainEvents
{
    public record CutsomerCreatedEvent (
        int CustomerId ,
        String CustomerName): IDomainEvent;

}
