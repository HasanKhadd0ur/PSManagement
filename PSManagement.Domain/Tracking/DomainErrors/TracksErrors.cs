using Ardalis.Result;
using PSManagement.SharedKernel.DomainErrors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Domain.Tracking.DomainErrors
{
    public class TracksErrors
    {
        public static DomainError InvalidEntryError { get; } = new("TrackError.InvalidEntry.", "Invalid Project Data");
        public static DomainError ParticipantTrackExistError { get; } = new("TrackError.Participant.Exist.", "the Project already have the given particpant Data");
        public static DomainError ParticipantTrackUnExistError { get; } = new("TrackError.Participant.UnExist.", "the Project doesnt have the given particpant Data");
        public static DomainError StepTrackExistError { get; } = new("TrackError.Step.Exist.", "the Project already have the given particpant Data");
        public static DomainError StepTrackUnExistError { get; } = new("TrackError.Step.UnExist.", "the Project doesnt have the given particpant Data");
        public static DomainError TrackCompletedUpdateError { get; } = new("TrackError.Update.complete.", "the track couldnt be update afert its completed");
        public static DomainError InvailEmployeeTrack { get; } = new("TrackError.Update.complete.", "the employee track is not correct");
    }
}
