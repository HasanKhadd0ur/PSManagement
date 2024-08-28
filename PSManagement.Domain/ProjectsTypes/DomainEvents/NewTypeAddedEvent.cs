using PSManagement.SharedKernel.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Domain.ProjectsTypes.DomainEvents
{
    public record NewTypeAddedEvent(
        string TypeName ,
        int Id 
        ):IDomainEvent;
}
