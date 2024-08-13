﻿using PSManagement.Domain.Projects.ValueObjects;

namespace PSManagement.Domain.Projects.Entities
{
    public class ProposedState : IProjectState
    {
        public string StateName => "Proposed";

        public void Approve(Project project, Aggreement projectAggreement)
        {

        }

        public void Cancle(Project project)
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
