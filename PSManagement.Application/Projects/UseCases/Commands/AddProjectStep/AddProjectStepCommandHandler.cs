using Ardalis.Result;
using PSManagement.Domain.Projects;
using PSManagement.Domain.Projects.DomainErrors;
using PSManagement.Domain.Projects.Entities;
using PSManagement.Domain.Projects.Repositories;
using PSManagement.SharedKernel.CQRS.Command;
using PSManagement.SharedKernel.Interfaces;
using PSManagement.SharedKernel.Specification;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Projects.UseCases.Commands.AddProjectStep
{
    public class AddProjectStepCommandHandler : ICommandHandler<AddProjectStepCommand, Result<int>>
    {
        private readonly IProjectsRepository _projectsRepository;
        private readonly IStepsRepository _stepsRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly BaseSpecification<Project> _specification;

        public AddProjectStepCommandHandler(
            IProjectsRepository projectsRepository,
            IUnitOfWork unitOfWork,
            IStepsRepository stepsRepository)
        {

            _projectsRepository = projectsRepository;
            _unitOfWork = unitOfWork;
            _specification = new ProjectSpecification();
           
            _stepsRepository = stepsRepository;
        }

        public async Task<Result<int>> Handle(AddProjectStepCommand request, CancellationToken cancellationToken)
        {
            Project project = await _projectsRepository.GetByIdAsync(request.ProjectId,_specification);
            if (project is null)
            {
                return Result.Invalid(ProjectsErrors.InvalidEntryError);
            }
            else
            {    
                Step  step = await _stepsRepository.AddAsync(new(request.StepInfo ,request.ProjectId,request.Weight));
                
                await _unitOfWork.SaveChangesAsync();
                
                return Result.Success(step.Id);
                


            }
        }
    }
}
