using Ardalis.Result;
using PSManagement.Application.Tracks.Common;
using PSManagement.SharedKernel.CQRS.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PSManagement.Application.Tracks.UseCaes.Queries.GetTracksByProject
{
    public record GetTracksByProjectQuery(
        int ProjectId,
        int? PageNumber,
        int? PageSize

        ) : IQuery<Result<IEnumerable<TrackDTO>>>;


}
