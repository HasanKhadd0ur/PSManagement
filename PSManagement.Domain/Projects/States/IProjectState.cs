using Ardalis.Result;
using PSManagement.Domain.Projects.ValueObjects;
using System;

namespace PSManagement.Domain.Projects.Entities
{
    public interface IProjectState
    {
        Result Complete(Project project, ProjectCompletion projectCompletion);
        Result Plan(Project project);
        Result Approve(Project project);
        Result Cancel(Project project, DateTime canellationTime);
        Result Propose(Project project);
        string StateName { get; }
    }

}
