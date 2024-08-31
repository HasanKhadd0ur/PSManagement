using Ardalis.Result;
using PSManagement.Domain.Employees.Repositories;
using PSManagement.Domain.Projects;
using PSManagement.Domain.Projects.DomainErrors;
using PSManagement.Domain.Projects.Entities;
using PSManagement.Domain.Projects.Repositories;
using PSManagement.SharedKernel.CQRS.Command;
using PSManagement.SharedKernel.Interfaces;
using PSManagement.SharedKernel.Specification;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Projects.UseCases.Commands.ChangeProjectManager
{
    public class ChangeEmployeeParticipationCommandHandler : ICommandHandler<ChangeEmployeeParticipationCommand, Result>
    {
        private readonly IProjectsRepository _projectsRepository;
        private readonly BaseSpecification<Project> _specification;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmployeesRepository _employeesRepository;


        public ChangeEmployeeParticipationCommandHandler(
            IProjectsRepository projectsRepository,
            IUnitOfWork unitOfWork,
            IEmployeesRepository employeesRepository)
        {

            _projectsRepository = projectsRepository;
            _unitOfWork = unitOfWork;
            _specification = new ProjectSpecification();
        }

        public async Task<Result> Handle(ChangeEmployeeParticipationCommand request, CancellationToken cancellationToken)
        {
            _specification.AddInclude(e => e.EmployeeParticipates);
            _specification.AddInclude("EmployeeParticipates.Employee");

            Project project = await _projectsRepository.GetByIdAsync(request.ProjectId,_specification);

            if (project is null)
            {
                return Result.Invalid(ProjectsErrors.InvalidEntryError);
            }
            else
            {
                if (!project.HasParticipant(request.ParticipantId)) {

                    return Result.Invalid(ProjectsErrors.ParticipantUnExistError);

                }


                project.ChangeParticipant(request.ParticipantId,request.PartialTimeRation,request.Role);


                await _unitOfWork.SaveChangesAsync();

                return Result.Success();



            }
        }
    }

}
