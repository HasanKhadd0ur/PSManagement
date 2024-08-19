using Ardalis.Result;
using PSManagement.Application.Projects.Common;
using PSManagement.SharedKernel.CQRS.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PSManagement.Application.Projects.UseCases.Queries.GetProjectById
{
    public record GetProjectByIdQuery(
         int ProjectId
          ) : IQuery<Result<ProjectDTO>>;
}
