using PSManagement.Domain.Projects.DomainEvents;
using PSManagement.Domain.Projects.ValueObjects;
using System;

namespace PSManagement.Domain.Projects.Entities
{
    public class InProgressState : IProjectState
    {
        public string StateName => "InProgress";

        public void Approve(Project project, Aggreement projectAggreement)
        {

        }

        public void Cancel(Project project, DateTime canellationTime)
        {
            project.AddDomainEvent(new ProjectCancelledEvent(project.Id,canellationTime));
            project.SetState(new CancledState());
        }

        public void Complete(Project project)
        {
            project.SetState(new CompletedState());
        }

        public void Plan(Project project)
        {
            project.SetState(new InPlanState());
        }

        public void Propose(Project project)
        {

        }
    }
}
