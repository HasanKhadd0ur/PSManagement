using Ardalis.Result;
using PSManagement.Domain.Projects.DomainErrors;
using PSManagement.Domain.Projects.DomainEvents;
using PSManagement.Domain.Projects.Entities;
using PSManagement.Domain.Projects.Repositories;
using PSManagement.SharedKernel.CQRS.Command;
using PSManagement.SharedKernel.Interfaces;
using PSManagement.SharedKernel.Repositories;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Projects.UseCases.Commands.RemoveParticipant
{
    public class AddParticipantCommandHandler : ICommandHandler<RemoveParticipantCommand, Result>
    {
        private readonly IProjectsRepository _projectsRepository;
        private readonly IRepository<EmployeeParticipate> _employeeParticipateRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddParticipantCommandHandler(
            IRepository<EmployeeParticipate> repository,
            IProjectsRepository projectsRepository,
            IUnitOfWork unitOfWork)
        {
            _employeeParticipateRepository = repository;

            _projectsRepository = projectsRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(RemoveParticipantCommand request, CancellationToken cancellationToken)
        {
            Project project = await _projectsRepository.GetByIdAsync(request.ProjectId);
            if (project is null)
            {
                return Result.Invalid(ProjectsErrors.InvalidEntryError);
            }
            else
            {

                if (project.EmployeeParticipates.Where(e => e.Id == request.ParticipantId) is null)
                {

                    return Result.Invalid(ProjectsErrors.ParticipantUnExistError);
                }
                else
                {
                    EmployeeParticipate participant = await _employeeParticipateRepository.GetByIdAsync(request.ParticipantId);

                    await _employeeParticipateRepository.DeleteAsync(participant);
                    project.AddDomainEvent(new ParticipantRemovedEvent(request.ParticipantId, request.ProjectId));

                    await _unitOfWork.SaveChangesAsync();

                    return Result.Success();
                }


            }
        }
    }

}
