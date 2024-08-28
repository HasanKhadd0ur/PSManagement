using Ardalis.Result;
using AutoMapper;
using PSManagement.Application.Tracks.Common;
using PSManagement.Domain.Projects.Repositories;
using PSManagement.Domain.Steps.Repositories;
using PSManagement.Domain.Tracking;
using PSManagement.Domain.Tracking.Specification;
using PSManagement.SharedKernel.CQRS.Query;
using PSManagement.SharedKernel.Specification;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Tracks.UseCaes.Queries.GetTracksByFilter
{
    public class GetTracksByFilterQueryHandler : IQueryHandler<GetTracksByFilterQuery, Result<IEnumerable<TrackDTO>>>
    {
        private readonly IProjectsRepository _projectsRepository;
        private readonly ITracksRepository _tracksRepository;
        private readonly IMapper _mapper;
        private readonly BaseSpecification<Track> _specification;

        public GetTracksByFilterQueryHandler(
            IMapper mapper,
            IProjectsRepository projectsRepository,
            ITracksRepository tracksRepository)
        {
            _mapper = mapper;
            _projectsRepository = projectsRepository;
            _specification = new TrackSpecification();
            _tracksRepository = tracksRepository;
        }

        public async Task<Result<IEnumerable<TrackDTO>>> Handle(GetTracksByFilterQuery request, CancellationToken cancellationToken)
        {
            _specification.ApplyOptionalPagination(request.PageSize, request.PageNumber);
            _specification.AddInclude(e => e.Project);
            var tracks = await _tracksRepository.ListAsync(_specification);

            return Result.Success(_mapper.Map<IEnumerable<TrackDTO>>(tracks));

        }
    }

}
