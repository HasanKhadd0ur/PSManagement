using PSManagement.Domain.Projects.DomainEvents;
using PSManagement.Domain.Projects.ValueObjects;
using System;

namespace PSManagement.Domain.Projects.Entities
{
    public class InPlanState : IProjectState
    {
        public string StateName => "InPlan";

        public void Approve(Project project, Aggreement projectAggreement)
        {

            project.ProjectAggreement = projectAggreement;
            project.AddDomainEvent(new ProjectApprovedEvent(project.Id,projectAggreement));
            project.SetState(new InProgressState());
        }

        public void Cancle(Project project)
        {
            project.AddDomainEvent(new ProjectCancelledEvent(project.Id,DateTime.Now));
            project.SetState(new CancledState());
        }

        public void Complete(Project project)
        {
            project.SetState(new CompletedState());
        }

        public void Plan(Project project)
        {

        }

        public void Propose(Project project)
        {

        }
    }
}
