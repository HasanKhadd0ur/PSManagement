using Ardalis.Result;
using AutoMapper;
using PSManagement.Domain.Projects.DomainErrors;
using PSManagement.Domain.Projects.Entities;
using PSManagement.Domain.Projects.Repositories;
using PSManagement.SharedKernel.CQRS.Command;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.ProjectsTypes.UseCases.Commands.CreateNewType
{
    public class CreateNewTypeCommandHandler : ICommandHandler<CreateNewTypeCommand, Result<int>>
    {
        private readonly IProjectTypesRepository _projectTypesRepository;
        private readonly IMapper _mapper;

        public CreateNewTypeCommandHandler(
            IMapper mapper,
            IProjectTypesRepository projectTypesRepository)
        {
            _projectTypesRepository = projectTypesRepository;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateNewTypeCommand request, CancellationToken cancellationToken)
        {
            var result = await _projectTypesRepository.GetByTypeName(request.TypeName);

            if (result.Count() !=0 )
            {
                return Result.Invalid(PrjectTypesErrors.InvalidName);
            }
            
            var projectType = await _projectTypesRepository.AddAsync(_mapper.Map<ProjectType>(request));
            
            return Result.Success(projectType.Id); 

        }
    }
}
