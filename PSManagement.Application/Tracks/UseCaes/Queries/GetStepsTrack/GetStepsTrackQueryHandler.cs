using Ardalis.Result;
using AutoMapper;
using PSManagement.Application.Tracks.Common;
using PSManagement.Domain.Steps.Repositories;
using PSManagement.Domain.Tracking.DomainErrors;
using PSManagement.Domain.Tracking.Entities;
using PSManagement.Domain.Tracking.Specification;
using PSManagement.SharedKernel.CQRS.Query;
using PSManagement.SharedKernel.Repositories;
using PSManagement.SharedKernel.Specification;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Tracks.UseCaes.Queries.GetStepsTrack
{
    public class GetStepsTrackQueryHandler : IQueryHandler<GetStepsTrackQuery, Result<IEnumerable<StepTrackDTO>>>
    {
        private readonly ITracksRepository _tracksRepository;
        private readonly IRepository<StepTrack> _stepTracksRepository;

        private readonly IMapper _mapper;
        private readonly BaseSpecification<StepTrack> _specification;
        public GetStepsTrackQueryHandler(
            IMapper mapper,
            ITracksRepository tracksRepository,
            IRepository<StepTrack> stepTracksRepository
            )
        {
            _mapper = mapper;
            _tracksRepository = tracksRepository;
            _specification = new StepTrackSpecification();
            _stepTracksRepository = stepTracksRepository;
        }


        public async Task<Result<IEnumerable<StepTrackDTO>>> Handle(GetStepsTrackQuery request, CancellationToken cancellationToken)
        {
            

            
            _specification.Criteria = t => t.TrackId == request.TrackId;
            _specification.AddInclude(e => e.Track);
            _specification.AddInclude(e => e.Step);


            var track = await _tracksRepository.GetByIdAsync(request.TrackId);
            if (track is null)
            {
                return Result.Invalid(TracksErrors.InvalidEntryError);
            }
            else
            {

                var stepTracks = await _stepTracksRepository.ListAsync(_specification);


                return Result.Success(_mapper.Map<IEnumerable<StepTrackDTO>>(stepTracks));

            }

        }
    }
}
