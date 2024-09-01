using Ardalis.Result;
using PSManagement.Domain.Projects;
using PSManagement.Domain.Projects.DomainErrors;
using PSManagement.Domain.Projects.Entities;
using PSManagement.Domain.Projects.Repositories;
using PSManagement.SharedKernel.CQRS.Command;
using PSManagement.SharedKernel.Interfaces;
using PSManagement.SharedKernel.Specification;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Projects.UseCases.Commands.ApproveProject
{
    public class ApproveProjectCommandHandler : ICommandHandler<ApproveProjectCommand, Result>
    {
        private readonly IProjectsRepository _projectsRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly BaseSpecification<Project> _specification;

        public ApproveProjectCommandHandler(
            IProjectsRepository projectsRepository,
            IUnitOfWork unitOfWork
            )
        {

            _projectsRepository = projectsRepository;
            _unitOfWork = unitOfWork;
            _specification = new ProjectSpecification();
        }

        public async Task<Result> Handle(ApproveProjectCommand request, CancellationToken cancellationToken)
        {
            _specification.AddInclude(e => e.Steps);

            Project project = await _projectsRepository.GetByIdAsync(request.ProjectId,_specification);
            
            if (project is null)
            {
                return Result.Invalid(ProjectsErrors.InvalidEntryError);
            }
            else
            {
                if (project.VailedSteps())
                {
                    Result result = project.Approve();
                    await _unitOfWork.SaveChangesAsync();
                    return result;

                }
                else {

                    return Result.Invalid(ProjectsErrors.InvalidStepWeight);
                    
                }





            }
        }
    }

}
