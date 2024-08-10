using MediatR;
using PSManagement.SharedKernel.Entities;
using PSManagement.SharedKernel.Events;
using PSManagement.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Infrastructure.Persistence.UoW
{
    public class UnitOfWork :IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        private readonly IMediator _mediator;
        public UnitOfWork(AppDbContext dbContext, IMediator mediator)
        {
            _dbContext = dbContext;
            _mediator = mediator;
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await DispatchEventsAsync();
            
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
        private async Task DispatchEventsAsync()
        {
            var processedDomainEvents = new List<IDomainEvent>();
            var unprocessedDomainEvents = GetDomainEvents().AsEnumerable();
            // this is needed incase another DomainEvent is published from a DomainEventHandler
            while (unprocessedDomainEvents.Any())
            {
                await DispatchDomainEventsAsync(unprocessedDomainEvents);
                processedDomainEvents.AddRange(unprocessedDomainEvents);
                unprocessedDomainEvents = GetDomainEvents()
                                            .Where(e => !processedDomainEvents.Contains(e))
                                            .ToList();
            }

            ClearDomainEvents();
        }

        private List<IDomainEvent> GetDomainEvents()
        {
            var aggregateRoots = GetTrackedEntites();
            return aggregateRoots
                .SelectMany(x => x.Events)
                .ToList();
        }

        private List<BaseEntity> GetTrackedEntites()
        {
            return _dbContext.ChangeTracker
                .Entries<BaseEntity>()
                .Where(x => x.Entity.Events != null && x.Entity.Events.Any())
                .Select(e => e.Entity)
                .ToList();
        }

        private async Task DispatchDomainEventsAsync(IEnumerable<IDomainEvent> domainEvents)
        {
            foreach (var domainEvent in domainEvents)
            {
                await _mediator.Publish(domainEvent);
            }
        }

        private void ClearDomainEvents()
        {
            var aggregateRoots = GetTrackedEntites();
            aggregateRoots.ForEach(aggregate => aggregate.ClearDomainEvents());
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

    }
}
