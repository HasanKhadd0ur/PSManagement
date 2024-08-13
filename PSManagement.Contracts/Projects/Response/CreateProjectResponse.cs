using PSManagement.Domain.Projects.ValueObjects;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Contracts.Projects.Response
{
    public record CreateProjectResponse(
         int ProjectId,
         ProposalInfo ProposalInfo,
         ProjectInfo ProjectInfo,
         Aggreement ProjectAggrement,
         int TeamLeaderId,
         int ProjectManagerId,
         int ExecuterId
        );

}
