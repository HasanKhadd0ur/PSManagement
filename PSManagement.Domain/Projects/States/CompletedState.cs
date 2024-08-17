using PSManagement.Domain.Projects.ValueObjects;
using System;

namespace PSManagement.Domain.Projects.Entities
{
    public class CompletedState : IProjectState
    {
        public string StateName => "Completed";

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

        }
    }
}
