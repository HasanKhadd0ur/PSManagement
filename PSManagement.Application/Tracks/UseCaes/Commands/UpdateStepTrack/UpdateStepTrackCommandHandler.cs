using Ardalis.Result;
using AutoMapper;
using PSManagement.Domain.Steps.Repositories;
using PSManagement.Domain.Tracking;
using PSManagement.Domain.Tracking.DomainErrors;
using PSManagement.Domain.Tracking.Entities;
using PSManagement.SharedKernel.CQRS.Command;
using PSManagement.SharedKernel.Interfaces;
using PSManagement.SharedKernel.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Tracks.UseCaes.Commands.UpdateStepTrack
{
    public class UpdateStepTrackCommandHandler : ICommandHandler<UpdateStepTrackCommand, Result>
    {
        private readonly IRepository<StepTrack> _stepTracksRepository;
        private readonly ITracksRepository _tracksRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateStepTrackCommandHandler(
            IUnitOfWork unitOfWork,
            ITracksRepository tracksRepository,
            IRepository<StepTrack> stepTracksRepository,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _tracksRepository = tracksRepository;
            _stepTracksRepository = stepTracksRepository;
            _mapper = mapper;
        }

        public async Task<Result> Handle(UpdateStepTrackCommand request, CancellationToken cancellationToken)
        {
            Track track = await _tracksRepository.GetByIdAsync(request.TrackId);

            if (track is null)
            {

                return Result.Invalid(TracksErrors.InvalidEntryError);

            }
            if (track.TrackInfo.IsCompleted)
            {

                return Result.Invalid(TracksErrors.TrackCompletedUpdateError);
            }

            StepTrack stepTrack = await _stepTracksRepository.GetByIdAsync(request.StepTrackId);
            if (stepTrack is null)
            {

                return Result.Invalid(TracksErrors.InvalidEntryError);

            }
            if (request.StepId != stepTrack.StepId)
            {

                return Result.Invalid(TracksErrors.InvalidEntryError);
            }

            stepTrack.ExecutionRatio = request.ExecutionRatio;
            stepTrack.ExecutionState = request.ExecutionState;

            await _stepTracksRepository.UpdateAsync(stepTrack);

            return Result.Success();

        }
    }

}
