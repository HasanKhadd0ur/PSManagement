using PSManagement.Domain.Projects.ValueObjects;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Contracts.Projects.Requests
{
    public record CreateProjectRequest(
        ProjectInfo ProjectInfo,
        ProposalInfo ProposalInfo,
        Aggreement ProjectAggreement,
        FinancialFund FinancialFund,
        int TeamLeaderId,
        int ProjectManagerId,
        int ProposerId,
        int ExecuterId);
}
