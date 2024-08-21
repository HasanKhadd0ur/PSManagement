using Ardalis.Result;
using PSManagement.Application.Contracts.Email;
using PSManagement.Domain.Projects.DomainErrors;
using PSManagement.Domain.Projects.Entities;
using PSManagement.Domain.Projects.Repositories;
using PSManagement.SharedKernel.CQRS.Command;
using PSManagement.SharedKernel.Interfaces;
using PSManagement.SharedKernel.Repositories;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using PSManagement.Domain.Projects.DomainEvents;
using PSManagement.SharedKernel.Specification;
using PSManagement.Domain.Projects;
using PSManagement.Domain.Employees.Entities;
using PSManagement.Domain.Employees.Repositories;
using PSManagement.Domain.Employees.DomainErrors;

namespace PSManagement.Application.Projects.UseCases.Commands.AddParticipant
{
    public class AddParticipantCommandHandler : ICommandHandler<AddParticipantCommand, Result>
    {
        private readonly IProjectsRepository _projectsRepository;
        private readonly IEmployeesRepository _employeesRepository;
        private readonly IRepository<EmployeeParticipate> _employeeParticipateRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly BaseSpecification<Project> _specification;

        public AddParticipantCommandHandler(
            IRepository<EmployeeParticipate> repository,
            IProjectsRepository projectsRepository,
            IUnitOfWork unitOfWork,
            IEmployeesRepository employeesRepository)
        {
            _employeeParticipateRepository = repository;
            _specification = new ProjectSpecification();
            _projectsRepository = projectsRepository;
            _unitOfWork = unitOfWork;
            _employeesRepository = employeesRepository;
        }

        public async Task<Result> Handle(AddParticipantCommand request, CancellationToken cancellationToken)
        {
            _specification.AddInclude(e => e.EmployeeParticipates);

            Project project =await _projectsRepository.GetByIdAsync(request.ProjectId,_specification);
            if (project is null)
            {
                return Result.Invalid(ProjectsErrors.InvalidEntryError);
            }else {

                if (project.EmployeeParticipates.Where(e => e.EmployeeId == request.ParticipantId).FirstOrDefault() is not  null)
                {

                    return Result.Invalid(ProjectsErrors.ParticipantExistError);
                }
                else {
                    
                    Employee employee = await _employeesRepository.GetByIdAsync(request.ParticipantId);
                    if (employee is null) {

                        return Result.Invalid(EmployeesErrors.EmployeeUnExist);

                    }

                    await _employeeParticipateRepository.AddAsync(new (request.ParticipantId,request.ProjectId,request.Role,request.PartialTimeRatio));
                    
                    project.AddDomainEvent(new ParticipantAddedEvent(request.ParticipantId,request.ProjectId,request.PartialTimeRatio,request.Role));

                    await _unitOfWork.SaveChangesAsync();
                    return Result.Success();
                }
            
            
            }
        }
    }

}
