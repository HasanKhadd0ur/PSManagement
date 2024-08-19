using Ardalis.Result;
using PSManagement.Domain.Projects.DomainErrors;
using PSManagement.Domain.Projects.ValueObjects;
using System;

namespace PSManagement.Domain.Projects.Entities
{
    public class CancledState : IProjectState
    {
        public string StateName => "CancledState";

        public Result Approve(Project project, Aggreement projectAggreement)
        {
            return Result.Invalid(ProjectsErrors.StateTracnsitionError("Cancelled","Approved"));
        }

        public Result Cancel(Project project, DateTime canellationTime)
        {
            return Result.Invalid(ProjectsErrors.StateTracnsitionError("Cancelled", "Cancelled"));
        }

        public Result Complete(Project project)
        {
            return Result.Invalid(ProjectsErrors.StateTracnsitionError("Cancelled", "Completed"));
        }

        public Result Plan(Project project)
        {
            return Result.Invalid(ProjectsErrors.StateTracnsitionError("Cancelled", "Plan"));
        }

        public Result Propose(Project project)
        {
            return Result.Invalid(ProjectsErrors.StateTracnsitionError("Cancelled", "Proposed"));
        }
    }
}
