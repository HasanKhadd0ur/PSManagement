using Ardalis.Result;
using PSManagement.Domain.Projects.ValueObjects;
using PSManagement.SharedKernel.CQRS.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PSManagement.Application.Projects.UseCases.Commands.ApproveProject
{
    public record ApproveProjectCommand(
        int ProjectId
        ): ICommand<Result>;

}
