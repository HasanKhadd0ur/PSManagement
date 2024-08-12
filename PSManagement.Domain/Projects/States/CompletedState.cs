﻿namespace PSManagement.Domain.Projects.Entities
{
    public class CompletedState : IProjectState
    {
        public string StateName => "Completed";

        public void Approve(Project project)
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

        }
    }
}