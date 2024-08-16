using Ardalis.Result;
using AutoMapper;
using PSManagement.Domain.Steps.Repositories;
using PSManagement.Domain.Tracking;
using PSManagement.Domain.Tracking.DomainErrors;
using PSManagement.Domain.Tracking.DomainEvents;
using PSManagement.SharedKernel.CQRS.Command;
using PSManagement.SharedKernel.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Tracks.UseCaes.Commands.CompleteTrack
{
    public class CompleteTrackCommandHandler : ICommandHandler<CompleteTrackCommand, Result>
    {
        private readonly ITracksRepository _tracksRepository;
        private readonly IUnitOfWork _unitOfWork;
        
        public CompleteTrackCommandHandler(
            
            IUnitOfWork unitOfWork,
            ITracksRepository tracksRepository
            )
        {

            _unitOfWork = unitOfWork;
            _tracksRepository = tracksRepository;
        }

        public async Task<Result> Handle(CompleteTrackCommand request, CancellationToken cancellationToken)
        {
            Track track = await _tracksRepository.GetByIdAsync(request.TrackId);

            if (track is null)
            {

                return Result.Invalid(TracksErrror.InvalidEntryError);

            }

            track.AddDomainEvent(new TrackCompleteddEvent(request.ProjectId, request.TrackId, request.TrackDate));

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();

        }
    }
}
