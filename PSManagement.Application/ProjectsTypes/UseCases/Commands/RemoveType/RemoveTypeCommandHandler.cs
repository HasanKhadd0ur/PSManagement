using Ardalis.Result;
using AutoMapper;
using PSManagement.Domain.Projects;
using PSManagement.Domain.Projects.DomainErrors;
using PSManagement.Domain.Projects.Entities;
using PSManagement.Domain.Projects.Repositories;
using PSManagement.SharedKernel.CQRS.Command;
using PSManagement.SharedKernel.Specification;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.ProjectsTypes.UseCases.Commands.CreateNewType
{
    public class RemoveTypeCommandHandler : ICommandHandler<RemoveTypeCommand, Result>
    {
        private readonly IProjectTypesRepository _projectTypesRepository;
        private readonly IMapper _mapper;
        private readonly BaseSpecification<ProjectType> _specification;
        public RemoveTypeCommandHandler(
            IMapper mapper,
            IProjectTypesRepository projectTypesRepository)
        {
            _projectTypesRepository = projectTypesRepository;
            _mapper = mapper;
            _specification = new ProjectTypeSpecification();
        }

        public async Task<Result> Handle(RemoveTypeCommand request, CancellationToken cancellationToken)
        {
            var result = await _projectTypesRepository.GetByIdAsync(request.typeId ,_specification);

            if (result is null)
            {
                return Result.Invalid(PrjectTypesErrors.InvalidEntryError);
            }
            if (result.Projects is not null )
            {
                return Result.Invalid(PrjectTypesErrors.InvalidEntryError);
            }

            await _projectTypesRepository.DeleteAsync(result);

            return Result.Success();

        }
    }
}
