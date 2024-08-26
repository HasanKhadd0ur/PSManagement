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
        #region Dependencies
       
        private readonly AppDbContext _dbContext;
        private readonly IMediator _mediator;

        #endregion Dependencies

        #region Constructor
        public UnitOfWork(AppDbContext dbContext, IMediator mediator)
        {
            _dbContext = dbContext;
            _mediator = mediator;
        }

        #endregion Constructor

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await DispatchEventsAsync();
            
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        #region Process  Events 
        private async Task DispatchEventsAsync()
        {
            // list for the processed event 
            var processedDomainEvents = new List<IDomainEvent>();
            // list of un processed events 
            var unprocessedDomainEvents = GetDomainEvents().AsEnumerable();
           
            // this is needed incase another DomainEvent is published from a DomainEventHandler
            while (unprocessedDomainEvents.Any())
            {
                // publish domain events 
                await DispatchDomainEventsAsync(unprocessedDomainEvents);
               
                // move the un processed to the processed 
                processedDomainEvents.AddRange(unprocessedDomainEvents);
                
                // get the newest un processed events 
                unprocessedDomainEvents = GetDomainEvents()
                                            .Where(e => !processedDomainEvents.Contains(e))
                                            .ToList();
            }

            // clear the events 
            ClearDomainEvents();
        }
        #endregion Process Events 

        #region Get Events 
        private List<IDomainEvent> GetDomainEvents()
        {
            // change tracker to the base entity 
            var aggregateRoots = GetTrackedEntites();
            
            //  get the events list 
            return aggregateRoots
                .SelectMany(x => x.Events)
                .ToList();
        }

        #endregion Get Events 

        #region Get Tracked
        private List<BaseEntity> GetTrackedEntites()
        {
            // change tracker to the base enties that has an events 
            return _dbContext.ChangeTracker
                .Entries<BaseEntity>()
                .Where(x => x.Entity.Events != null && x.Entity.Events.Any())
                .Select(e => e.Entity)
                .ToList();
        }
        #endregion Get Tracked 
        
        #region Dispatch Events 
        private async Task DispatchDomainEventsAsync(IEnumerable<IDomainEvent> domainEvents)
        {
            foreach (var domainEvent in domainEvents)
            {
                await _mediator.Publish(domainEvent);
            }
        }

        #endregion Dispatch Events 

        #region Clear And Dispose 
        private void ClearDomainEvents()
        {
            var aggregateRoots = GetTrackedEntites();
            aggregateRoots.ForEach(aggregate => aggregate.ClearDomainEvents());
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
        #endregion Clear And Dispose 
    }
}
