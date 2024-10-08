﻿using Ardalis.Result;
using PSManagement.SharedKernel.CQRS.Command;
using System;

namespace PSManagement.Application.Tracks.UseCaes.Commands.AddStepTrack
{
    public record AddStepTrackCommand(
        int StepId,
        int TrackId,
        string ExecutionState,
        int TrackExecutionRatio
    ) : ICommand<Result<int>>;
}