﻿using PSManagement.SharedKernel.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Domain.Projects.DomainEvents
{
    public record ProjectCancelledEvent(
        int ProjectId,
        DateTime CancellationTime) : IDomainEvent;
}
