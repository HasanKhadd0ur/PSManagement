using Ardalis.Result;
using AutoMapper;
using PSManagement.Application.Tracks.Common;
using PSManagement.Domain.Steps.Repositories;
using PSManagement.Domain.Tracking;
using PSManagement.Domain.Tracking.Specification;
using PSManagement.SharedKernel.CQRS.Query;
using PSManagement.SharedKernel.Specification;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Tracks.UseCaes.Queries.GetUncompletedTracks
{
    public class GetUnCompletedTracksQueryHandler : IQueryHandler<GetUnCompletedTracksQuery, Result<IEnumerable<TrackDTO>>>
    {
        private readonly ITracksRepository _tracksRepository;
        private readonly IMapper _mapper;
        private readonly BaseSpecification<Track> _specification;

        public GetUnCompletedTracksQueryHandler(
            IMapper mapper,
            ITracksRepository tracksRepository)
        {
            _mapper = mapper;
            _tracksRepository = tracksRepository;
            _specification = new TrackSpecification();
        }

        public async Task<Result<IEnumerable<TrackDTO>>> Handle(GetUnCompletedTracksQuery request, CancellationToken cancellationToken)
        {

            _specification.Criteria = c => c.TrackInfo.IsCompleted == false;
            _specification.AddInclude(e => e.Project);
            var tracks = await _tracksRepository.ListAsync(_specification);


            return Result.Success(_mapper.Map<IEnumerable<TrackDTO>>(tracks));

        }
    }

}
