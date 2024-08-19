using Ardalis.Result;
using PSManagement.Domain.Projects.DomainErrors;
using PSManagement.Domain.Projects.DomainEvents;
using PSManagement.Domain.Projects.ValueObjects;
using System;

namespace PSManagement.Domain.Projects.Entities
{
    public class InPlanState : IProjectState
    {
        public string StateName => "InPlan";

        public Result Approve(Project project, Aggreement projectAggreement)
        {

            project.ProjectAggreement = projectAggreement;
            project.AddDomainEvent(new ProjectApprovedEvent(project.Id,projectAggreement));
            project.SetState(new InProgressState());
            return Result.Success();
        }

        public Result Cancel(Project project, DateTime canellationTime)
        {
            project.AddDomainEvent(new ProjectCancelledEvent(project.Id,DateTime.Now));
            project.SetState(new CancledState());
            return Result.Success();

        }

        public Result Complete(Project project)
        {
            project.AddDomainEvent(new ProjectCompletedEvent(project.Id));
            project.SetState(new CompletedState());
            return Result.Success();
        }

        public Result Plan(Project project)
        {
            return Result.Invalid(ProjectsErrors.StateTracnsitionError("In Plainning ", "In Planning"));
        }

        public Result Propose(Project project)
        {
            return Result.Invalid(ProjectsErrors.StateTracnsitionError("Approved", "Proposed"));

        }
    }
}
