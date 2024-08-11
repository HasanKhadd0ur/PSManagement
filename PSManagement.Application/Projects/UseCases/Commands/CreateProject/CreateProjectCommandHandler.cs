using Ardalis.Result;
using PSManagement.Application.Projects.Common;
using PSManagement.Domain.Projects.Builders;
using PSManagement.Domain.Projects.Entities;
using PSManagement.Domain.Projects.Repositories;
using PSManagement.SharedKernel.CQRS.Command;
using PSManagement.SharedKernel.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Projects.UseCases.Commands.CreateProject
{
    public class CreateProjectCommandHandler : ICommandHandler<CreateProjectCommand, Result<CreateProjectResponse>>
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

        public async Task<Result<CreateProjectResponse>> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
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
            Project AddedProject =await _projectsRepository.AddAsync(project);
            CreateProjectResponse response = new (
                AddedProject.Id,
                AddedProject.ProposalInfo,
                AddedProject.ProjectInfo,
                AddedProject.ProjectAggreement,
                AddedProject.TeamLeaderId,
                AddedProject.ProjectManagerId,
                AddedProject.ExecuterId
                );
            await _unitOfWork.SaveChangesAsync();
            return Result.Success(response);

        }
    }
}
