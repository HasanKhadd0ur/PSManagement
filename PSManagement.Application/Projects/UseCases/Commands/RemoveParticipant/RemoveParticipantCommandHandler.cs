using Ardalis.Result;
using PSManagement.Domain.Projects;
using PSManagement.Domain.Projects.DomainErrors;
using PSManagement.Domain.Projects.DomainEvents;
using PSManagement.Domain.Projects.Entities;
using PSManagement.Domain.Projects.Repositories;
using PSManagement.SharedKernel.CQRS.Command;
using PSManagement.SharedKernel.Interfaces;
using PSManagement.SharedKernel.Repositories;
using PSManagement.SharedKernel.Specification;
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
        private readonly BaseSpecification<Project> _specification;

        public AddParticipantCommandHandler(
            IRepository<EmployeeParticipate> repository,
            IProjectsRepository projectsRepository,
            IUnitOfWork unitOfWork)
        {
            _employeeParticipateRepository = repository;
            _specification = new ProjectSpecification();
            _projectsRepository = projectsRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(RemoveParticipantCommand request, CancellationToken cancellationToken)
        {
            _specification.AddInclude(e => e.EmployeeParticipates);

            Project project = await _projectsRepository.GetByIdAsync(request.ProjectId,_specification);
            if (project is null)
            {
                return Result.Invalid(ProjectsErrors.InvalidEntryError);
            }
            else
            {
                if (project.EmployeeParticipates is null) {

                    return Result.Invalid(ProjectsErrors.ParticipantUnExistError);
                
                }
                var employeeParticipate =project.EmployeeParticipates.Where(e => e.EmployeeId == request.ParticipantId).FirstOrDefault();
                if (employeeParticipate is null) {

                    return Result.Invalid(ProjectsErrors.ParticipantUnExistError);
                }

                
               await _employeeParticipateRepository.DeleteAsync(employeeParticipate);
     
               project.AddDomainEvent(new ParticipantRemovedEvent(request.ParticipantId, request.ProjectId));

               await _unitOfWork.SaveChangesAsync();

                return Result.Success();


            }
        }
    }

}
