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
         int? ProjectManagerId,
         int? TeamLeaderId,
         int? PageNumber,
         int? PageSize,
         string ProposerName
     ) : IQuery<Result<IEnumerable<ProjectDetailsDTO>>>;

}
