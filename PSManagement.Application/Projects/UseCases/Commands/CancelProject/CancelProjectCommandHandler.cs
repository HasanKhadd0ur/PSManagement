using Ardalis.Result;
using PSManagement.Application.Contracts.Providers;
using PSManagement.Domain.Projects.DomainErrors;
using PSManagement.Domain.Projects.Entities;
using PSManagement.Domain.Projects.Repositories;
using PSManagement.SharedKernel.CQRS.Command;
using PSManagement.SharedKernel.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Projects.UseCases.Commands.CancelProject
{
    public class CancelProjectCommandHandler : ICommandHandler<CancelProjectCommand, Result>
    {
        private readonly IProjectsRepository _projectsRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateTimeProvider _dateTime;

        public CancelProjectCommandHandler(
            IProjectsRepository projectsRepository,
            IUnitOfWork unitOfWork,
            IDateTimeProvider dateTime)
        {

            _projectsRepository = projectsRepository;
            _unitOfWork = unitOfWork;
            _dateTime = dateTime;
        }

        public async Task<Result> Handle(CancelProjectCommand request, CancellationToken cancellationToken)
        {
            Project project = await _projectsRepository.GetByIdAsync(request.ProjectId);
            if (project is null)
            {
                return Result.Invalid(ProjectsErrors.InvalidEntryError);
            }
            else
            {

                project.Cancel(_dateTime.UtcNow);
                await _unitOfWork.SaveChangesAsync();

                return Result.Success();



            }
        }
    }

}
