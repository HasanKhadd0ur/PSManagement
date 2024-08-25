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
    public class GetProjectsByFilterQueryHandler : IQueryHandler<GetProjectsByFilterQuery, Result<IEnumerable<ProjectDetailsDTO>>>
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

        public async Task<Result<IEnumerable<ProjectDetailsDTO>>> Handle(GetProjectsByFilterQuery request, CancellationToken cancellationToken)
        {
            _specification.AddInclude(e => e.TeamLeader);
            _specification.AddInclude(e => e.Executer);
            _specification.AddInclude(e => e.Proposer);
            _specification.ApplyOptionalPagination(request.PageSize, request.PageNumber);


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
            if (request.ProjectManagerId.HasValue) {
                projects = projects.Where(p => p.ProjectManagerId == request.ProjectManagerId);
            }
            if (request.TeamLeaderId.HasValue)
            {
                projects = projects.Where(p => p.TeamLeaderId == request.TeamLeaderId);
            }
            return Result.Success(_mapper.Map<IEnumerable<ProjectDetailsDTO>>(projects));
        }
    }

}
