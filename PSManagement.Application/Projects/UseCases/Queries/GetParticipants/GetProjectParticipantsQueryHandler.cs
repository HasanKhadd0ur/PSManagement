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

namespace PSManagement.Application.Projects.UseCases.Queries.GetParticipants
{
    public class GetProjectParticipantsQueryHandler : IQueryHandler<GetProjectParticipantsQuery, Result<IEnumerable<EmployeeParticipateDTO>>>
    {
        private readonly IProjectsRepository _projectRepository;
        private readonly IMapper _mapper;
        private readonly BaseSpecification<Project> _specification;

        public GetProjectParticipantsQueryHandler(
            IProjectsRepository projectRepository,
            IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
            _specification = new ProjectSpecification();
        }

        public async Task<Result<IEnumerable<EmployeeParticipateDTO>>> Handle(GetProjectParticipantsQuery request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetByIdAsync(request.ProjectId);
            if (project == null)
            {
                return Result.NotFound("Project not found");
            }
            _specification.AddInclude(p => p.EmployeeParticipates);
            _specification.AddInclude("EmployeeParticipates.Employee");
            _specification.AddInclude("EmployeeParticipates.Project");

            IEnumerable<EmployeeParticipateDTO> result = _mapper.Map<IEnumerable<EmployeeParticipateDTO>>(_projectRepository.GetProjectParticipants(request.ProjectId,_specification));
            if (result is null)
            {
                result = new List<EmployeeParticipateDTO>();
            }
            result = result.Select(e => { e.ProjectInfo = project.ProjectInfo; return e; });
            return Result.Success(result);
        }
    }

}
