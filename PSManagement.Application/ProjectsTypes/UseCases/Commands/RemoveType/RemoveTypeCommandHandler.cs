using Ardalis.Result;
using AutoMapper;
using PSManagement.Domain.Projects;
using PSManagement.Domain.Projects.DomainErrors;
using PSManagement.Domain.Projects.Repositories;
using PSManagement.Domain.ProjectsTypes.Entites;
using PSManagement.SharedKernel.CQRS.Command;
using PSManagement.SharedKernel.Specification;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

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
            _specification.AddInclude(e => e.Projects);

            var result = await _projectTypesRepository.GetByIdAsync(request.typeId ,_specification);

            if (result is null)
            {
                return Result.Invalid(ProjectTypesErrors.InvalidEntryError);
            }
            if (result.Projects.Count()!=0 )
            {
                return Result.Invalid(ProjectTypesErrors.UnEmptyProjects);
            }

            await _projectTypesRepository.DeleteAsync(result);

            return Result.Success();

        }
    }
}
