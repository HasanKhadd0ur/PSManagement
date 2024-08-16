using Ardalis.Result;
using AutoMapper;
using PSManagement.Domain.Steps.Repositories;
using PSManagement.Domain.Tracking;
using PSManagement.Domain.Tracking.DomainEvents;
using PSManagement.SharedKernel.CQRS.Command;
using PSManagement.SharedKernel.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Tracks.UseCaes.Commands.CreateTrack
{
    public class CreateTrackCommandHandler : ICommandHandler<CreateTrackCommand, Result<int>>
    {
        private readonly ITracksRepository _tracksRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateTrackCommandHandler(
            IMapper mapper,
            IUnitOfWork unitOfWork,
            ITracksRepository tracksRepository
            )
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _tracksRepository = tracksRepository;
        }

        public async Task<Result<int>> Handle(CreateTrackCommand request, CancellationToken cancellationToken)
        {
            Track track = _mapper.Map<Track>(request);
            track = await _tracksRepository.AddAsync(track);
            track.AddDomainEvent(new TrackCreatedEvent(request.ProjectId,request.TrackInfo.TrackDate));

            await _unitOfWork.SaveChangesAsync();
            return Result.Success(track.Id);

        }
    }
}
