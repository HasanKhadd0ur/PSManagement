using Ardalis.Result;
using AutoMapper;
using PSManagement.Domain.Projects.DomainErrors;
using PSManagement.Domain.Projects.Entities;
using PSManagement.Domain.Projects.Repositories;
using PSManagement.SharedKernel.CQRS.Command;
using PSManagement.SharedKernel.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Projects.UseCases.Commands.CompleteProgressProject
{
    public class CompleteProjectCommandHandler : ICommandHandler<CompleteProjectCommand, Result>
    {
        private readonly IProjectsRepository _projectsRepository;
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public CompleteProjectCommandHandler(
            IProjectsRepository projectsRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {

            _projectsRepository = projectsRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result> Handle(CompleteProjectCommand request, CancellationToken cancellationToken)
        {
            Project project = await _projectsRepository.GetByIdAsync(request.ProjectId);
            if (project is null)
            {
                return Result.Invalid(ProjectsErrors.InvalidEntryError);
            }
            else{
                
                Result result = project.Complete(_mapper.Map<ProjectCompletion>(request));
                await _unitOfWork.SaveChangesAsync();
                return result;
            }
        }
    }

}
