using MediatR;
using System;

namespace PSManagement.SharedKernel.Events
{
    public interface  IDomainEvent : INotification
    {
        public DateTime DateOccurred { get; set; }
        
    }
}
