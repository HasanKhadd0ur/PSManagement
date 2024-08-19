using Ardalis.Result;
using PSManagement.Domain.Projects.DomainErrors;
using PSManagement.Domain.Projects.Entities;
using PSManagement.Domain.Projects.Repositories;
using PSManagement.SharedKernel.CQRS.Command;
using PSManagement.SharedKernel.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Projects.UseCases.Commands.CompleteProgressProject
{
    public class CompleteProgressProjectCommandHandler : ICommandHandler<CompleteProgressProjectCommand, Result>
    {
        private readonly IProjectsRepository _projectsRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CompleteProgressProjectCommandHandler(
            IProjectsRepository projectsRepository,
            IUnitOfWork unitOfWork
            )
        {

            _projectsRepository = projectsRepository;
            _unitOfWork = unitOfWork;

        }

        public async Task<Result> Handle(CompleteProgressProjectCommand request, CancellationToken cancellationToken)
        {
            Project project = await _projectsRepository.GetByIdAsync(request.ProjectId);
            if (project is null)
            {
                return Result.Invalid(ProjectsErrors.InvalidEntryError);
            }
            else{
                
                Result result = project.Complete();
                await _unitOfWork.SaveChangesAsync();
                return result;
            }
        }
    }

}
