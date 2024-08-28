using Ardalis.Result;
using AutoMapper;
using PSManagement.Application.Projects.Common;
using PSManagement.Domain.Projects;
using PSManagement.Domain.Projects.DomainErrors;
using PSManagement.Domain.Projects.Entities;
using PSManagement.Domain.Projects.Repositories;
using PSManagement.SharedKernel.CQRS.Query;
using PSManagement.SharedKernel.Specification;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Projects.UseCases.Queries.GetProjectCompletion
{
    public class GetProjectCompletionQueryHandler : IQueryHandler<GetProjectCompletionQuery, Result<ProjectCompletionDTO>>
    {
        private readonly IProjectsRepository _projectsRepository;

        private readonly BaseSpecification<Project> _projectSpecification;
        private readonly IMapper _mapper;
        public GetProjectCompletionQueryHandler(
            IProjectsRepository projectsRepository,
            IMapper mapper)
        {
            _projectSpecification = new ProjectSpecification();
            _projectsRepository = projectsRepository;

            _mapper = mapper;
        }

        public async Task<Result<ProjectCompletionDTO>> Handle(GetProjectCompletionQuery request, CancellationToken cancellationToken)
        {
            _projectSpecification.AddInclude(e => e.ProjectCompletion);

            Project project = await _projectsRepository.GetByIdAsync(request.ProjectId, _projectSpecification);

            if (project is null)
            {
                return Result.Invalid(ProjectsErrors.InvalidEntryError);
            }
            else
            {
                if (project.ProjectCompletion is null)
                {

                    return Result.Invalid(ProjectsErrors.UnCompletedError);
                }

                var result = _mapper.Map<ProjectCompletionDTO>(project.ProjectCompletion);
                return Result.Success(result);


            }
        }
    }

}
