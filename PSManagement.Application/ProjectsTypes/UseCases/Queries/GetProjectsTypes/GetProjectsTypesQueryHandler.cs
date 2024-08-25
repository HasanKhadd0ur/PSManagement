using Ardalis.Result;
using AutoMapper;
using PSManagement.Application.ProjectsTypes.Common;
using PSManagement.Domain.Projects.Entities;
using PSManagement.Domain.Projects.Repositories;
using PSManagement.SharedKernel.CQRS.Query;
using PSManagement.SharedKernel.Specification;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.ProjectsTypes.UseCases.Queries.GetProjectsTypes
{
    public class GetProjectsTypesQueryHandler : IQueryHandler<GetProjectsTypesQuery, Result<IEnumerable<ProjectTypeDTO>>>
    {
        private readonly IProjectTypesRepository _projectTypesRepository;
        private readonly IMapper _mapper;
        private readonly BaseSpecification<ProjectType> _specification;

        public GetProjectsTypesQueryHandler(
            IMapper mapper,
            IProjectTypesRepository projectTypesRepository)
        {
            _projectTypesRepository = projectTypesRepository;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<ProjectTypeDTO>>> Handle(GetProjectsTypesQuery request, CancellationToken cancellationToken)
        {
            var result = await _projectTypesRepository.ListAsync();

            if (result is null)
            {
                result = new List<ProjectType>();
            }

            return Result.Success(_mapper.Map<Result<IEnumerable<ProjectTypeDTO>>>(result)); ;
        }
    }
}
