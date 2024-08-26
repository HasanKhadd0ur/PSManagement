using PSManagement.Domain.Projects.DomainEvents;
using PSManagement.Domain.Projects.Entities;
using PSManagement.SharedKernel.DomainEvents;
using PSManagement.SharedKernel.Interfaces;
using PSManagement.SharedKernel.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Projects.EventsHandlers
{
    public class ChangeRegisterationOnParticipationChangedEventHandler : IDomainEventHandler<ParticipationChangedEvent>
    {
        private readonly IRepository<ParticipationChange> _repository;
        private readonly IUnitOfWork _unitOfWork;
        public ChangeRegisterationOnParticipationChangedEventHandler(IRepository<ParticipationChange> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(ParticipationChangedEvent notification, CancellationToken cancellationToken)
        {

            await _repository
                .AddAsync(
                new ParticipationChange {
                PartialTimeAfter= notification.PartialTimeRatioAfter ,
                PartialTimeBefore= notification.PartialTimeRatioBefore ,
                EmployeeId=notification.ParticipantId,
                ProjectId=notification.ProjectId,
                ChangeDate=notification.DateTime,
                RoleAfter=notification.RoleAfter,
                RoleBefore=notification.RoleBefore

                });



        }
    }

}
