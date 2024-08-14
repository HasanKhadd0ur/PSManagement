using Ardalis.Result;
using AutoMapper;
using PSManagement.Application.Projects.Common;
using PSManagement.Domain.Projects;
using PSManagement.Domain.Projects.Entities;
using PSManagement.Domain.Projects.Repositories;
using PSManagement.SharedKernel.CQRS.Query;
using PSManagement.SharedKernel.Specification;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Projects.UseCases.Queries.ListAllProject
{
    public class GetProjectsByFilterQueryHandler : IQueryHandler<GetProjectsByFilterQuery, Result<IEnumerable<ProjectDTO>>>
    {
        private readonly IProjectsRepository _projectsRepository;
        private readonly IMapper _mapper;

        public GetProjectsByFilterQueryHandler(
            IMapper mapper,
            IProjectsRepository projectsRepository)
        {
            _mapper = mapper;
            _projectsRepository = projectsRepository;
            _specification = new ProjectSpecification();
        }

        private readonly BaseSpecification<Project> _specification;

        public async Task<Result<IEnumerable<ProjectDTO>>> Handle(GetProjectsByFilterQuery request, CancellationToken cancellationToken)
        {
            _specification.AddInclude(e => e.TeamLeader);
            _specification.AddInclude(e => e.Executer);
            _specification.AddInclude(e => e.Proposer);


            IEnumerable<Project> projects = await _projectsRepository.ListAsync(_specification);
            if (!string.IsNullOrEmpty(request.DepartmentName))
            {
                projects = projects.Where(e => e.Executer.Name.ToLower().Contains(request.DepartmentName.Trim().ToLower()));
            }

            if (!string.IsNullOrEmpty(request.ProposerName))
            {
                projects = projects.Where(e => e.Proposer.CustomerName.ToLower().Contains(request.ProposerName.Trim().ToLower()));
            }

            if (!string.IsNullOrEmpty(request.TeamLeaderName))
            {
                projects = projects.Where(e => e.Proposer.CustomerName.ToLower().Contains(request.TeamLeaderName.Trim().ToLower()));
            }

            if (!string.IsNullOrEmpty(request.ProposerName))
            {
                projects = projects.Where(e => e.ProjectInfo.Name.ToLower().Contains(request.ProjectName.Trim().ToLower()));
            }


            return Result.Success(_mapper.Map<IEnumerable<ProjectDTO>>(projects));
        }
    }

}
