using Ardalis.Result;
using PSManagement.Application.Projects.Common;
using PSManagement.SharedKernel.CQRS.Query;
using System.Collections.Generic;

namespace PSManagement.Application.Projects.UseCases.Queries.ListAllProject
{
    public record GetProjectsByFilterQuery(
         string ProjectName,
         string TeamLeaderName,
         string DepartmentName,
         string ProposerName
     ) : IQuery<Result<IEnumerable<ProjectDTO>>>;

}
