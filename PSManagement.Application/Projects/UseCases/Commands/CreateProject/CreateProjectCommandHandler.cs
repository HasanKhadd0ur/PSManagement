using Ardalis.Result;
using PSManagement.Application.Projects.Common;
using PSManagement.Domain.Projects.Builders;
using PSManagement.Domain.Projects.DomainErrors;
using PSManagement.Domain.Projects.DomainEvents;
using PSManagement.Domain.Projects.Entities;
using PSManagement.Domain.Projects.Repositories;
using PSManagement.SharedKernel.CQRS.Command;
using PSManagement.SharedKernel.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Projects.UseCases.Commands.CreateProject
{
    public class CreateProjectCommandHandler : ICommandHandler<CreateProjectCommand, Result<int>>
    {
        private readonly IProjectsRepository _projectsRepository;
        private readonly IProjectTypesRepository _projectTypesRepository;
        private readonly ProjectBuilder _projectBuilder;
        private readonly IUnitOfWork _unitOfWork;


        public CreateProjectCommandHandler(
            IProjectsRepository projectsRepository,
            ProjectBuilder projectBuilder,
            IUnitOfWork unitOfWork, IProjectTypesRepository projectTypesRepository)
        {
            _projectsRepository = projectsRepository;
            _projectBuilder = projectBuilder;
            _unitOfWork = unitOfWork;
            _projectTypesRepository = projectTypesRepository;
        }

        public async Task<Result<int>> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {

            var type = await _projectTypesRepository.GetByIdAsync(request.ProjectTypeId);
            if (type is null) { 
            
                return Result.Invalid(ProjectTypesErrors.InvalidEntryError);
            }

            Project project = _projectBuilder
                .WithProjectAggreement(request.ProjectAggreement)
                .WithProjectInfo(request.ProjectInfo)
                .WithProposalInfo(request.ProposalInfo)
                .WithExecuter(request.ExecuterId)
                .WithFinancialFund(request.FinancialFund)
                .WithProjectManager(request.ProjectManagerId)
                .WithTeamLeader(request.TeamLeaderId)
                .WithProposer(request.ProposerId)
                .WithClassification(request.ProjectClassification)
                .Build();


            project.ProjectTypeId = request.ProjectTypeId;

            project.Propose();

            project =await _projectsRepository.AddAsync(project);
           

            project.AddDomainEvent(new ProjectCreatedEvent(project.Id,project.TeamLeaderId,project.ProjectManagerId));
            
            await _unitOfWork.SaveChangesAsync();
            
            return Result.Success(project.Id);

        }
    }
}
