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

namespace PSManagement.Application.Tracks.UseCaes.Commands.AddStepTrack
{
    public class AddStepTrackCommandHandler : ICommandHandler<AddStepTrackCommand, Result<int>>
    {
        private readonly IRepository<StepTrack> _stepTracksRepository;
        private readonly ITracksRepository _tracksRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddStepTrackCommandHandler(
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

        public async Task<Result<int>> Handle(AddStepTrackCommand request, CancellationToken cancellationToken)
        {
            Track track = await _tracksRepository.GetByIdAsync(request.TrackId);

            if (track is null)
            {

                return Result.Invalid(TracksErrors.InvalidEntryError);

            }

            StepTrack stepTrack = await _stepTracksRepository.AddAsync(_mapper.Map<StepTrack>(request));

            await _unitOfWork.SaveChangesAsync();

            return Result.Success(stepTrack.Id);

        }
    }
}