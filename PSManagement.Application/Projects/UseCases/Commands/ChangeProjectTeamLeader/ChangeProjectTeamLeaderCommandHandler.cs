using Ardalis.Result;
using PSManagement.Domain.Employees.DomainErrors;
using PSManagement.Domain.Employees.Entities;
using PSManagement.Domain.Employees.Repositories;
using PSManagement.Domain.Projects.DomainErrors;
using PSManagement.Domain.Projects.Entities;
using PSManagement.Domain.Projects.Repositories;
using PSManagement.SharedKernel.CQRS.Command;
using PSManagement.SharedKernel.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Projects.UseCases.Commands.ChangeProjectTeamLeader
{
    public class ChangeProjectTeamLeaderCommandHandler : ICommandHandler<ChangeProjectTeamLeaderCommand, Result>
    {
        private readonly IProjectsRepository _projectsRepository;
        private readonly IEmployeesRepository _employeesRepository;

        private readonly IUnitOfWork _unitOfWork;

        public ChangeProjectTeamLeaderCommandHandler(
            IProjectsRepository projectsRepository,
            IUnitOfWork unitOfWork,
            IEmployeesRepository employeesRepository)
        {

            _projectsRepository = projectsRepository;
            _unitOfWork = unitOfWork;
            _employeesRepository = employeesRepository;
        }

        public async Task<Result> Handle(ChangeProjectTeamLeaderCommand request, CancellationToken cancellationToken)
        {
            Project project = await _projectsRepository.GetByIdAsync(request.ProjectId);
            if (project is null)
            {
                return Result.Invalid(ProjectsErrors.InvalidEntryError);
            }
            else
            {
                Employee teamLeader = await _employeesRepository.GetByIdAsync(request.EmployeeId);
                if (teamLeader is null)
                {
                    return Result.Invalid(EmployeesErrors.EmployeeUnExist);
                }
                project.TeamLeader = teamLeader;
                project.TeamLeaderId = request.EmployeeId;
                await _projectsRepository.UpdateAsync(project);

                await _unitOfWork.SaveChangesAsync();

                return Result.Success();



            }
        }
    }

}
