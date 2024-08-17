using PSManagement.Domain.Projects.ValueObjects;
using System;

namespace PSManagement.Domain.Projects.Entities
{
    public class ProposedState : IProjectState
    {
        public string StateName => "Proposed";

        public void Approve(Project project, Aggreement projectAggreement)
        {

        }

        public void Cancel(Project project, DateTime canellationTime)
        {
        
        }

        public void Complete(Project project)
        {
        
        }

        public void Plan(Project project)
        {
        
        }

        public void Propose(Project project)
        {
            project.SetState(new InPlanState());
        }
    }

}
