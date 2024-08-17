using Ardalis.Result;
using PSManagement.Application.Projects.Common;
using PSManagement.Domain.Projects.ValueObjects;
using PSManagement.SharedKernel.CQRS.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PSManagement.Application.Projects.UseCases.Commands.CreateProject
{
    public record CreateProjectCommand(
        ProjectInfo ProjectInfo ,
        ProposalInfo ProposalInfo,
        Aggreement ProjectAggreement,
        FinancialFund FinancialFund,
        int TeamLeaderId ,
        int ProjectManagerId,
        int ProposerId,
        int ExecuterId
        ) : ILoggableCommand<Result<int>>;
}
