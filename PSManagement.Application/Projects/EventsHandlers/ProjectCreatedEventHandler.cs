using PSManagement.Application.Contracts.Email;
using PSManagement.Domain.Employees.Entities;
using PSManagement.Domain.Employees.Repositories;
using PSManagement.Domain.Employees.Specification;
using PSManagement.Domain.Projects.DomainEvents;
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
    public class ProjectCreatedEventHandler:IDomainEventHandler<ProjectCreatedEvent>
    {
        private readonly IEmailService _emailService;
        private readonly IEmployeesRepository _employeesRepository;
        private readonly BaseSpecification<Employee> _specification;

        public ProjectCreatedEventHandler(
            IEmailService emailService,
            IEmployeesRepository employeesRepository)
        {
            _emailService = emailService;
            _employeesRepository = employeesRepository;
            _specification = new EmployeesSpecification();
        }

        public async Task Handle(ProjectCreatedEvent notification, CancellationToken cancellationToken)
        {
            _specification.AddInclude(e => e.User);
            
            Employee projectManager = await _employeesRepository.GetByIdAsync(notification.ProjectManagerId,_specification);

            Employee teamLeader = await _employeesRepository.GetByIdAsync(notification.TeamLeaderId,_specification);

            await _emailService.SendAsync(
                projectManager.User.Email,
                "Manage a new Project ",
                "Mr"+projectManager.PersonalInfo.FirstName+ " you are chosen to Manage a new Project \n ");

            await _emailService.SendAsync(
                teamLeader.User.Email,
                "Lead a new Project ",
                "Mr" + teamLeader.PersonalInfo.FirstName + " you are chosen to lead a new Project \n ");

        }
    }
}
