using Ardalis.Result;
using PSManagement.Application.Projects.Common;
using PSManagement.Domain.Projects.Builders;
using PSManagement.Domain.Projects.DomainEvents;
using PSManagement.Domain.Projects.Entities;
using PSManagement.Domain.Projects.Repositories;
using PSManagement.SharedKernel.CQRS.Command;
using PSManagement.SharedKernel.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Projects.UseCases.Commands.CreateProject
{
    public class CreateProjectCommandHandler : ICommandHandler<CreateProjectCommand, Result<CreateProjectResult>>
    {
        private readonly IProjectsRepository _projectsRepository;
        private readonly ProjectBuilder _projectBuilder;
        private readonly IUnitOfWork _unitOfWork;


        public CreateProjectCommandHandler(
            IProjectsRepository projectsRepository,
            ProjectBuilder projectBuilder,
            IUnitOfWork unitOfWork)
        {
            _projectsRepository = projectsRepository;
            _projectBuilder = projectBuilder;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<CreateProjectResult>> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            Project project = _projectBuilder
                .WithProjectAggreement(request.ProjectAggreement)
                .WithProjectInfo(request.ProjectInfo)
                .WithProposalInfo(request.ProposalInfo)
                .WithExecuter(request.ExecuterId)
                .WithFinancialFund(request.FinancialFund)
                .WithProjectManager(request.ProjectManagerId)
                .WithTeamLeader(request.TeamLeaderId)
                .WithProposer(request.ProposerId)
                .Build();
            
            project.Propose();

            project =await _projectsRepository.AddAsync(project);
            CreateProjectResult response = new (
                project.Id,
                project.ProposalInfo,
                project.ProjectInfo,
                project.ProjectAggreement,
                project.TeamLeaderId,
                project.ProjectManagerId,
                project.ExecuterId
                );

            project.AddDomainEvent(new ProjectCreatedEvent(project.Id,project.TeamLeaderId,project.ProjectManagerId));
            await _unitOfWork.SaveChangesAsync();
            return Result.Success(response);

        }
    }
}
