using PSManagement.Domain.Projects.ValueObjects;
using System;

namespace PSManagement.Domain.Projects.Entities
{
    public interface IProjectState
    {
        void Complete(Project project);
        void Plan(Project project);
        void Approve(Project project, Aggreement projectAggreement);
        void Cancel(Project project, DateTime canellationTime);
        void Propose(Project project);
        string StateName { get; }
    }

}
