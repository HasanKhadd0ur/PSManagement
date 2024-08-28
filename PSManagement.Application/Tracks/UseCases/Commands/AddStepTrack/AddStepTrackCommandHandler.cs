using Ardalis.Result;
using AutoMapper;
using PSManagement.Domain.Projects.DomainErrors;
using PSManagement.Domain.Projects.Entities;
using PSManagement.Domain.Projects.Repositories;
using PSManagement.Domain.Steps.Repositories;
using PSManagement.Domain.Tracking;
using PSManagement.Domain.Tracking.DomainErrors;
using PSManagement.Domain.Tracking.Entities;
using PSManagement.Domain.Tracking.Specification;
using PSManagement.SharedKernel.CQRS.Command;
using PSManagement.SharedKernel.Interfaces;
using PSManagement.SharedKernel.Repositories;
using PSManagement.SharedKernel.Specification;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Tracks.UseCaes.Commands.AddStepTrack
{
    public class AddStepTrackCommandHandler : ICommandHandler<AddStepTrackCommand, Result<int>>
    {
        private readonly IRepository<StepTrack> _stepTracksRepository;
        private readonly ITracksRepository _tracksRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly BaseSpecification<Track> _specification;
        private readonly IStepsRepository _stepsRepository;

        public AddStepTrackCommandHandler(
            IUnitOfWork unitOfWork,
            ITracksRepository tracksRepository,
            IRepository<StepTrack> stepTracksRepository,
            IMapper mapper,
            IStepsRepository stepsRepository)
        {
            _unitOfWork = unitOfWork;
            _tracksRepository = tracksRepository;
            _stepTracksRepository = stepTracksRepository;
            _mapper = mapper;
            _specification = new TrackSpecification();
            _stepsRepository = stepsRepository;
        }

        public async Task<Result<int>> Handle(AddStepTrackCommand request, CancellationToken cancellationToken)
        {
            _specification.AddInclude(e => e.StepTracks);
            Track track = await _tracksRepository.GetByIdAsync(request.TrackId,_specification);

            if (track is null)
            {

                return Result.Invalid(TracksErrors.InvalidEntryError);

            }
            if (track.TrackInfo.IsCompleted)
            {

                return Result.Invalid(TracksErrors.TrackCompletedUpdateError);
            }

            if (track.StepTracks.Any(e => e.StepId == request.StepId))
            {

                return Result.Invalid(TracksErrors.StepTrackExistError);

            }
            Step step = await _stepsRepository.GetByIdAsync(request.StepId);
            if (step is null) {

                return Result.Invalid(StepsErrors.InvalidEntryError);
            
            }

            StepTrack stepTrack = _mapper.Map<StepTrack>(request);
            stepTrack.OldExecutionRatio = step.CurrentCompletionRatio;

            stepTrack = await _stepTracksRepository.AddAsync(stepTrack);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success(stepTrack.Id);

        }
    }
}