using FluentResults;
using PSManagement.Application.Projects.Common;
using PSManagement.Domain.Projects.Repositories;
using PSManagement.SharedKernel.CQRS.Command;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Projects.UseCases.Commands.CreateProject
{
    public class CreateProjectCommandHandler : ICommandHandler<CreateProjectCommand, Result<ProjectDTO>>
    {
        private readonly IProjectsRepository _projectsRepository;

        public CreateProjectCommandHandler(IProjectsRepository projectsRepository)
        {
            _projectsRepository = projectsRepository;
        }

        public Task<Result<ProjectDTO>> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            
            return Task.FromResult<Result<ProjectDTO>>(Result.Fail(new Error("")));

        }
    }
}
