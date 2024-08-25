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
    public class ListAllProjectsQueryHandler : IQueryHandler<ListAllProjectsQuery, Result<IEnumerable<ProjectDetailsDTO>>>
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

        public async Task<Result<IEnumerable<ProjectDetailsDTO>>> Handle(ListAllProjectsQuery request, CancellationToken cancellationToken)
        {
            _specification.ApplyOptionalPagination(request.PageSize, request.PageNumber);
            _specification.AddInclude(e => e.ProjectManager);
            _specification.AddInclude(e => e.Proposer);
            _specification.AddInclude(e => e.TeamLeader);
            _specification.AddInclude(e => e.Executer);



            
            var projects = await _projectsRepository.ListAsync(_specification);

            return Result.Success(_mapper.Map<IEnumerable<ProjectDetailsDTO>>(projects));    
        }
    }

}
