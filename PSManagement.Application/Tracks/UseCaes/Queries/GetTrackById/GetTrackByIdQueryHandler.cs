using Ardalis.Result;
using AutoMapper;
using PSManagement.Application.Tracks.Common;
using PSManagement.Domain.Projects.Repositories;
using PSManagement.Domain.Steps.Repositories;
using PSManagement.Domain.Tracking;
using PSManagement.Domain.Tracking.DomainErrors;
using PSManagement.Domain.Tracking.Specification;
using PSManagement.SharedKernel.CQRS.Query;
using PSManagement.SharedKernel.Specification;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Tracks.UseCaes.Queries.GetTrackById
{
    public class GetTrackByIdQueryHandler : IQueryHandler<GetTrackByIdQuery, Result<TrackDTO>>
    {
        private readonly IProjectsRepository _projectsRepository;
        private readonly ITracksRepository _tracksRepository;
        private readonly IMapper _mapper;
        private readonly BaseSpecification<Track> _specification;

        public GetTrackByIdQueryHandler(
            IMapper mapper,
            IProjectsRepository projectsRepository,
            ITracksRepository tracksRepository)
        {
            _mapper = mapper;
            _projectsRepository = projectsRepository;
            _specification = new TrackSpecification();
            _tracksRepository = tracksRepository;
        }

        public async Task<Result<TrackDTO>> Handle(GetTrackByIdQuery request, CancellationToken cancellationToken)
        {



            _specification.AddInclude(e => e.Project);


            Track track = await _tracksRepository.GetByIdAsync(request.TrackId,_specification);
            if (track is null) {

                return Result.Invalid(TracksErrors.InvalidEntryError);
            
            }

            return Result.Success(_mapper.Map<TrackDTO>(track));


        }
    }

}
