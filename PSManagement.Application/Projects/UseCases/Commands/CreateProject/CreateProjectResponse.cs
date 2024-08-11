using PSManagement.Domain.Projects.ValueObjects;

namespace PSManagement.Application.Projects.UseCases.Commands.CreateProject
{
    public record CreateProjectResponse(
         int ProjectId,
         ProposalInfo ProposalInfo ,
         ProjectInfo ProjectInfo,
         Aggreement ProjectAggrement,
         int TeamLeaderId ,
         int ProjectManagerId,
         int ExecuterId 
        );
}
