using Ardalis.Result;
using AutoMapper;
using PSManagement.Application.ProjectsTypes.Common;
using PSManagement.Application.ProjectsTypes.UseCases.Queries.GetProjectsTypes;
using PSManagement.Domain.Projects.DomainErrors;
using PSManagement.Domain.Projects.Repositories;
using PSManagement.SharedKernel.CQRS.Query;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.ProjectsTypes.UseCases.Queries.GetTypeById
{
    public class GetTypeByIdQueryHandler : IQueryHandler<GetTypeByIdQuery, Result<ProjectTypeDTO>>
    {
        private readonly IProjectTypesRepository _projectTypesRepository;
        private readonly IMapper _mapper;

        public GetTypeByIdQueryHandler(
            IMapper mapper,
            IProjectTypesRepository projectTypesRepository)
        {
            _projectTypesRepository = projectTypesRepository;
            _mapper = mapper;
        }

        public async Task<Result<ProjectTypeDTO>> Handle(GetTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _projectTypesRepository.GetByIdAsync(request.TypeId);

            if (result is null)
            {

                return Result.Invalid(ProjectTypesErrors.InvalidEntryError);
            }

            return Result.Success(_mapper.Map<ProjectTypeDTO>(result)); ;
        }
    }
}
