using Ardalis.Result;
using AutoMapper;
using PSManagement.Application.Projects.Common;
using PSManagement.Domain.Projects;
using PSManagement.Domain.Projects.Entities;
using PSManagement.Domain.Projects.Repositories;
using PSManagement.SharedKernel.CQRS.Query;
using PSManagement.SharedKernel.Specification;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Projects.UseCases.Queries.ListAllProject
{
    public class ListAllProjectsQueryHandler : IQueryHandler<ListAllProjectsQuery, Result<IEnumerable<ProjectDTO>>>
    {
        private readonly IProjectsRepository _projectsRepository;
        private readonly BaseSpecification<Project> _specification;
        private readonly IMapper _mapper;

        public ListAllProjectsQueryHandler(
            IProjectsRepository projectsRepository, 
            IMapper mapper)
        {
            _projectsRepository = projectsRepository;
            _specification = new ProjectSpecification();
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<ProjectDTO>>> Handle(ListAllProjectsQuery request, CancellationToken cancellationToken)
        {
            int pageNumber=request.PageNumber.HasValue && request.PageNumber.Value > 0 ? request.PageNumber.Value : 1;
            int pageSize = request.PageSize.HasValue && request.PageSize.Value > 0 && request.PageSize.Value <= 30 ? request.PageSize.Value : 30;
            _specification.AddInclude(e => e.ProjectManager);
            _specification.AddInclude(e => e.Proposer);
            _specification.AddInclude(e => e.TeamLeader);
            _specification.AddInclude(e => e.Executer);



            _specification.ApplyPaging((pageNumber - 1) * pageSize, pageSize);

            var projects = await _projectsRepository.ListAsync(_specification);

            return Result.Success(_mapper.Map<IEnumerable<ProjectDTO>>(projects));    
        }
    }

}
