using Ardalis.Result;
using PSManagement.SharedKernel.DomainErrors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Domain.Projects.DomainErrors
{
    public class ProjectsErrors
    {
        public static DomainError InvalidEntryError { get; } = new ("ProjectError.InvalidEntry.", "Invalid Project Data");
        public static DomainError ParticipantExistError { get; } = new("ProjectError.Participant.Exist.", "the Project already have the given particpant Data");
        public static DomainError ParticipantUnExistError { get; } = new("ProjectError.Participant.UnExist.", "the Project doesnt have the given particpant Data");
        public static DomainError StateTracnsitionError (string from, string to) => new("ProjectError.StateTransitionError","you cannot change the project state from " +from +" to "+to); 

    }
}
