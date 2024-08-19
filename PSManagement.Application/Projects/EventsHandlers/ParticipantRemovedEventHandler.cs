using PSManagement.Application.Contracts.Email;
using PSManagement.Domain.Employees.Entities;
using PSManagement.Domain.Employees.Repositories;
using PSManagement.Domain.Employees.Specification;
using PSManagement.Domain.Projects.DomainEvents;
using PSManagement.Domain.Projects.Entities;
using PSManagement.Domain.Projects.Repositories;
using PSManagement.SharedKernel.DomainEvents;
using PSManagement.SharedKernel.Specification;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Projects.EventsHandlers
{
    public class ParticipantRemovedEventHandler : IDomainEventHandler<ParticipantRemovedEvent>
    {
        private readonly IEmailService _emailService;
        private readonly IEmployeesRepository _employeesRepository;
        private readonly IProjectsRepository _projectsRepository;
        private readonly BaseSpecification<Employee> _specification;
        public ParticipantRemovedEventHandler(
            IEmployeesRepository employeesRepository,
            IEmailService emailService,
            IProjectsRepository projectsRepository)
        {
            _employeesRepository = employeesRepository;
            _emailService = emailService;
            _specification = new EmployeesSpecification();
            _projectsRepository = projectsRepository;
        }

        public async Task Handle(ParticipantRemovedEvent notification, CancellationToken cancellationToken)
        {
            _specification.AddInclude(e => e.User);
            
            Employee employee = await _employeesRepository.GetByIdAsync(notification.EmployeeId ,_specification);
            Project project = await _projectsRepository.GetByIdAsync(notification.ProjectId);

            await _emailService
                        .SendAsync(
                                employee.User.Email,
                                "Participation Cancelled",
                                "we are sorry Mr."+employee.PersonalInfo.FirstName+" but you are removed from the project "+project.ProjectInfo.Name);
        }
    }
}
