using Ardalis.Result;
using PSManagement.Domain.Projects.ValueObjects;
using System;

namespace PSManagement.Domain.Projects.Entities
{
    public interface IProjectState
    {
        Result Complete(Project project);
        Result Plan(Project project);
        Result Approve(Project project, Aggreement projectAggreement);
        Result Cancel(Project project, DateTime canellationTime);
        Result Propose(Project project);
        string StateName { get; }
    }

}
