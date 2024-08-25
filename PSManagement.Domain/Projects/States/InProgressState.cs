using Ardalis.Result;
using PSManagement.Domain.Projects.DomainErrors;
using PSManagement.Domain.Projects.DomainEvents;
using PSManagement.Domain.Projects.ValueObjects;
using System;

namespace PSManagement.Domain.Projects.Entities
{
    public class InProgressState : IProjectState
    {
        public string StateName => "InProgress";

        public Result Approve(Project project)
        {
            return Result.Invalid(ProjectsErrors.StateTracnsitionError("InProgress", "Approved"));

        }

        public Result Cancel(Project project, DateTime canellationTime)
        {
            project.AddDomainEvent(new ProjectCancelledEvent(project.Id,canellationTime));
            project.SetState(new CancledState());
            
            return Result.Success();
        }

        public Result Complete(Project project, ProjectCompletion projectCompletion)
        {
            project.ProjectCompletion = projectCompletion;
            project.AddDomainEvent(new ProjectCompletedEvent(project.Id));
            project.SetState(new CompletedState());
            return Result.Success();
        }

        public Result Plan(Project project)
        {
            project.SetState(new InPlanState());
            return Result.Success();
        }

        public Result Propose(Project project)
        {
            return Result.Invalid(ProjectsErrors.StateTracnsitionError("InProgress", "Proposed"));
        }
    }
}
