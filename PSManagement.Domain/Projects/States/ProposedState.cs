using Ardalis.Result;
using PSManagement.Domain.Projects.DomainErrors;
using PSManagement.Domain.Projects.DomainEvents;
using PSManagement.Domain.Projects.ValueObjects;
using System;

namespace PSManagement.Domain.Projects.Entities
{
    public class ProposedState : IProjectState
    {
        public string StateName => "Proposed";

        public Result Approve(Project project, Aggreement projectAggreement)
        {
            return Result.Invalid(ProjectsErrors.StateTracnsitionError("Proposed", "Approved"));

        }

        public Result Cancel(Project project, DateTime canellationTime)
        {
            return Result.Invalid(ProjectsErrors.StateTracnsitionError("Proposed", "Canceled"));

        }

        public Result Complete(Project project)
        {
            return Result.Invalid(ProjectsErrors.StateTracnsitionError("Proposed", "Completed"));

        }

        public Result Plan(Project project)
        {
            return Result.Invalid(ProjectsErrors.StateTracnsitionError("Propose", "In Planing"));

        }

        public Result Propose(Project project)
        {
            project.SetState(new InPlanState());
            return Result.Success();
        }
    }

}
