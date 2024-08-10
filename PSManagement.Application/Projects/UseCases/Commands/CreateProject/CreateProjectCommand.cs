using FluentResults;
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
        int TeamLeaderId ,
        int ProjectManagerId,
        int ProposerId
        ) : ICommand<Result<ProjectDTO>>;

}
