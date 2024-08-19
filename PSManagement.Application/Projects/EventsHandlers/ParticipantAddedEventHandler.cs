using PSManagement.Application.Contracts.Email;
using PSManagement.Domain.Employees.Entities;
using PSManagement.Domain.Employees.Repositories;
using PSManagement.Domain.Employees.Specification;
using PSManagement.Domain.Projects.DomainEvents;
using PSManagement.Domain.Projects.Entities;
using PSManagement.Domain.Projects.Repositories;
using PSManagement.SharedKernel.DomainEvents;
using PSManagement.SharedKernel.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Projects.EventsHandlers
{
    public class ParticipantAddedEventHandler : IDomainEventHandler<ParticipantAddedEvent>
    {
        private readonly IEmailService _emailService;
        private readonly IEmployeesRepository _employeesRepository;
        private readonly IProjectsRepository _projectsRepository;
        private readonly BaseSpecification<Employee> _specification;
        public ParticipantAddedEventHandler(
            IEmployeesRepository employeesRepository,
            IEmailService emailService,
            IProjectsRepository projectsRepository)
        {
            _employeesRepository = employeesRepository;
            _emailService = emailService;
            _specification = new EmployeesSpecification();
            _projectsRepository = projectsRepository;
        }

        public async Task Handle(ParticipantAddedEvent notification, CancellationToken cancellationToken)
        {
            _specification.AddInclude(e => e.User);

            Employee employee = await _employeesRepository.GetByIdAsync(notification.EmployeeId, _specification);
            Project project = await _projectsRepository.GetByIdAsync(notification.ProjectId);

            await _emailService
                        .SendAsync(
                                employee.User.Email,
                                "Project Participation ",
                                "Hello Mr."
                                    + employee.PersonalInfo.FirstName +
                                 " you have a new participation in the project " + project.ProjectInfo.Name
                                    +" with the role "+notification.Role
                                    +" with the partial time ratio "+ notification.PartialTimeRatio
                                    +" \n"
                                 );
        }
    }


}
