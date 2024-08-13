using Ardalis.Result;
using AutoMapper;
using PSManagement.Application.Projects.Common;
using PSManagement.Domain.Projects;
using PSManagement.Domain.Projects.Entities;
using PSManagement.Domain.Projects.Repositories;
using PSManagement.SharedKernel.CQRS.Query;
using PSManagement.SharedKernel.Specification;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Projects.UseCases.Queries.GetProject
{
    public class GetProjectByIdQueryHandler : IQueryHandler<GetProjectByIdQuery, Result<ProjectDTO>>
    {
        private readonly IProjectsRepository _projectRepository;
        private readonly BaseSpecification<Project> _specification;
        private readonly IMapper _mapper;

        public GetProjectByIdQueryHandler(
            IProjectsRepository projectRepository,
            IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
            _specification = new ProjectSpecification();
        }

        public async Task<Result<ProjectDTO>> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            _specification.Includes.Add(p=> p.EmployeeParticipates);
            _specification.Includes.Add(p => p.FinancialSpending);
            _specification.Includes.Add(p => p.ProjectManager);
            _specification.Includes.Add(p => p.Attachments);
            _specification.Includes.Add(p => p.TeamLeader);
            _specification.Includes.Add(p => p.Executer);



            var project = await _projectRepository.GetByIdAsync(request.ProjectId,_specification);
            if (project == null)
            {
                return Result.NotFound("Project not found");
            }

            return _mapper.Map<ProjectDTO>(project);
        }
    }
}
