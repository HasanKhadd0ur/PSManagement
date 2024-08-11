using System;

namespace PSManagement.Domain.Projects.ValueObjects
{
    public record ProposalInfo(
        int ProposingBookNumber,
        DateTime ProposingBookDate
        );

}
