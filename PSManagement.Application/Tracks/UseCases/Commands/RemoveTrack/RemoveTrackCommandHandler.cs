using Ardalis.Result;
using PSManagement.Domain.Steps.Repositories;
using PSManagement.Domain.Tracking;
using PSManagement.Domain.Tracking.DomainErrors;
using PSManagement.SharedKernel.CQRS.Command;
using PSManagement.SharedKernel.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Tracks.UseCaes.Commands.RemoveTrack
{
    public class RemoveTrackCommandHandler : ICommandHandler<RemoveTrackCommand, Result>
    {
        private readonly ITracksRepository _tracksRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveTrackCommandHandler(
            IUnitOfWork unitOfWork,
            ITracksRepository tracksRepository
            )
        {

            _unitOfWork = unitOfWork;
            _tracksRepository = tracksRepository;
        }

        public async Task<Result> Handle(RemoveTrackCommand request, CancellationToken cancellationToken)
        {
            Track track = await _tracksRepository.GetByIdAsync(request.TrackId);

            if (track is null)
            {

                return Result.Invalid(TracksErrors.InvalidEntryError);

            }

            await _tracksRepository.DeleteAsync(track);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();

        }
    }
}