using Ardalis.Result;
using PSManagement.SharedKernel.CQRS.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace PSManagement.Application.Projects.UseCases.Commands.AddParticipant
{
    public record  AddParticipantCommand(
        int ProjectId,
        int ParticipantId,
        int PartialTimeRatio,
        String Role 
        ):ICommand<Result>;
}
