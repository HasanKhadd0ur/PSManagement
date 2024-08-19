using Ardalis.Result;
using PSManagement.Domain.Projects.DomainErrors;
using PSManagement.Domain.Projects.ValueObjects;
using System;

namespace PSManagement.Domain.Projects.Entities
{
    public class CompletedState : IProjectState
    {
        public string StateName => "Completed";

        public Result Approve(Project project, Aggreement projectAggreement)
        {
            return Result.Invalid(ProjectsErrors.StateTracnsitionError("Approved", "Approved"));
        }

        public Result Cancel(Project project, DateTime canellationTime)
        {
            return Result.Invalid(ProjectsErrors.StateTracnsitionError("Approved", "Cancelled"));
        }

        public Result Complete(Project project)
        {
            return Result.Invalid(ProjectsErrors.StateTracnsitionError("Approved", "Completed"));
        }

        public Result Plan(Project project)
        {
            return Result.Invalid(ProjectsErrors.StateTracnsitionError("Approved", "InPlan"));

        }

        public Result Propose(Project project)
        {
            return Result.Invalid(ProjectsErrors.StateTracnsitionError("Approved", "Proposed"));

        }
    }
}
