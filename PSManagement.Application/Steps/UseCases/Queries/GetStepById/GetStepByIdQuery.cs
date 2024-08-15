using Ardalis.Result;
using PSManagement.Application.Projects.Common;
using PSManagement.SharedKernel.CQRS.Query;

namespace PSManagement.Application.Steps.UseCases.Queries.GetStepById
{
    public record GetStepByIdQuery(
        int StepId
    ) : IQuery<Result<StepDTO>>;

}
