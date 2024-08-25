using Ardalis.Result;
using PSManagement.Application.ProjectsTypes.Common;
using PSManagement.SharedKernel.CQRS.Query;

namespace PSManagement.Application.ProjectsTypes.UseCases.Queries.GetTypeById
{
    public record GetTypeByIdQuery(
        int TypeId
    ) : IQuery<Result<ProjectTypeDTO>>;
}
