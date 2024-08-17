using Ardalis.Result;
using PSManagement.Application.Tracks.Common;
using PSManagement.SharedKernel.CQRS.Query;
using System.Collections.Generic;

namespace PSManagement.Application.Tracks.UseCaes.Queries.GetEmployeesTrack
{
    public record GetEmployeesTrackQuery(
        int TrackId
    ) : IQuery<Result<IEnumerable<EmployeeTrackDTO>>>;
}
