using Ardalis.Result;
using PSManagement.Domain.Projects.ValueObjects;
using PSManagement.SharedKernel.CQRS.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PSManagement.Application.Projects.UseCases.Commands.AddProjectStep
{
    public record AddProjectStepCommand(
        int ProjectId,
        StepInfo StepInfo,
        int CurrentCompletionRatio,
        int Weight
        ):ICommand<Result<int>>;

}
