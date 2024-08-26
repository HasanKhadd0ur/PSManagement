using PSManagement.Application.Contracts.Email;
using PSManagement.Domain.Employees.Entities;
using PSManagement.Domain.Employees.Repositories;
using PSManagement.Domain.Projects.DomainEvents;
using PSManagement.SharedKernel.DomainEvents;
using PSManagement.SharedKernel.Specification;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Projects.EventsHandlers
{
    public class NotifieParticipantOnParticipationChangedEventHandler : IDomainEventHandler<ParticipationChangedEvent>
    {
        private readonly IEmailService _emailService;
        private readonly IEmployeesRepository _employeeRepository;
        private readonly BaseSpecification<Employee> _specification;
        
        public NotifieParticipantOnParticipationChangedEventHandler(IEmailService emailService, IEmployeesRepository employeeRepository)
        {
            _emailService = emailService;
            _employeeRepository = employeeRepository;
        }

        public async Task Handle(ParticipationChangedEvent notification, CancellationToken cancellationToken)
        {
            _specification.AddInclude(e => e.User);

            Employee employee = await _employeeRepository.GetByIdAsync(notification.ParticipantId,_specification);
            
            await _emailService.SendAsync(
                employee.User.Email,
                "Participation Change",
                "Mr,"+employee.PersonalInfo.FirstName +"your particiaption changed to "+notification.RoleAfter + notification.PartialTimeRatioAfter
                
                );

            
        }
    }

}
