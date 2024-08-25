using Ardalis.Result;
using PSManagement.Domain.Projects.DomainErrors;
using PSManagement.Domain.Projects.ValueObjects;
using System;

namespace PSManagement.Domain.Projects.Entities
{
    public class CompletedState : IProjectState
    {
        public string StateName => "Completed";

        public Result Approve(Project project)
        {
            return Result.Invalid(ProjectsErrors.StateTracnsitionError("Completed", "Approved"));
        }

        public Result Cancel(Project project, DateTime canellationTime)
        {
            return Result.Invalid(ProjectsErrors.StateTracnsitionError("Completed", "Cancelled"));
        }

        public Result Complete(Project project , ProjectCompletion ProjectCompletion)
        {
            return Result.Invalid(ProjectsErrors.StateTracnsitionError("Completed", "Completed"));
        }

        public Result Plan(Project project)
        {
            return Result.Invalid(ProjectsErrors.StateTracnsitionError("Completed", "InPlan"));

        }

        public Result Propose(Project project)
        {
            return Result.Invalid(ProjectsErrors.StateTracnsitionError("Completed", "Proposed"));

        }
    }
}
