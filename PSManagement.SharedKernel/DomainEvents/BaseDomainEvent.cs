using MediatR;
using System;

namespace PSManagement.SharedKernel.Events
{
    public abstract class BaseDomainEvent : INotification
    {
        public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
    }
}
