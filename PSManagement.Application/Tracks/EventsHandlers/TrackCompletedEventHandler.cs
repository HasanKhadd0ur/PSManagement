using PSManagement.Application.Contracts.Occupancy;
using PSManagement.Domain.Steps.Repositories;
using PSManagement.Domain.Tracking;
using PSManagement.Domain.Tracking.DomainEvents;
using PSManagement.Domain.Tracking.Specification;
using PSManagement.SharedKernel.DomainEvents;
using PSManagement.SharedKernel.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Tracks.EventsHandlers
{
    class TrackCompletedEventHandler : IDomainEventHandler<TrackCompletedEvent>
    {
        private readonly IOccupancySystemNotifier _occupancySystemNotifier;
        private readonly ITracksRepository _trackRepository;
        private readonly BaseSpecification<Track> _specification;

        public TrackCompletedEventHandler(
            ITracksRepository trackRepository,
            IOccupancySystemNotifier occupancySystemNotifier)
        {
            _trackRepository = trackRepository;
            _occupancySystemNotifier = occupancySystemNotifier;
            _specification = new TrackSpecification();
        }

        public async Task Handle(TrackCompletedEvent notification, CancellationToken cancellationToken)
        {
            _specification.AddInclude(s => s.EmployeeTracks);

            Track track = await _trackRepository.GetByIdAsync(notification.TrackId , _specification);

            foreach (EmployeeTrack employeeTrack in track.EmployeeTracks) {

                await _occupancySystemNotifier.SendEmployeeOccupancyNotification(employeeTrack);
                
            }


        }
    }
}
