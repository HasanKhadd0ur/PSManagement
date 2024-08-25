using Ardalis.Result;
using PSManagement.SharedKernel.CQRS.Command;
using System;

namespace PSManagement.Application.Projects.UseCases.Commands.CompleteProgressProject
{
    public record CompleteProjectCommand(
        int ProjectId,
        DateTime CompletionDate,
        String CustomerNotes,
        int CustomerRate 
        ) : ICommand<Result>;

}
