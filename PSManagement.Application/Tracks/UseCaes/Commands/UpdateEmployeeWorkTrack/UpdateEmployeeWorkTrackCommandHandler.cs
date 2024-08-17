using Ardalis.Result;
using AutoMapper;
using PSManagement.Domain.Steps.Repositories;
using PSManagement.Domain.Tracking;
using PSManagement.Domain.Tracking.DomainErrors;
using PSManagement.SharedKernel.CQRS.Command;
using PSManagement.SharedKernel.Interfaces;
using PSManagement.SharedKernel.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Tracks.UseCaes.Commands.UpdateEmployeeWorkTrack
{
    public class UpdateEmployeeWorkTrackCommandHandler : ICommandHandler<UpdateEmployeeWorkTrackCommand, Result>
    {
        private readonly IRepository<EmployeeTrack> _employeeTracksRepository;
        private readonly ITracksRepository _tracksRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateEmployeeWorkTrackCommandHandler(
            IUnitOfWork unitOfWork,
            ITracksRepository tracksRepository,
            IRepository<EmployeeTrack> employeeTracksRepository,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _tracksRepository = tracksRepository;
            _employeeTracksRepository = employeeTracksRepository;
            _mapper = mapper;
        }

        public async Task<Result> Handle(UpdateEmployeeWorkTrackCommand request, CancellationToken cancellationToken)
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
            EmployeeTrack employeeTrack = await _employeeTracksRepository.GetByIdAsync(request.EmployeeTrackId);
            if (employeeTrack is null)
            {

                return Result.Invalid(TracksErrors.InvalidEntryError);

            }
            if (request.EmployeeId != employeeTrack.EmloyeeId)
            {

                return Result.Invalid(TracksErrors.InvalidEntryError);
            }

            employeeTrack.EmployeeWork = request.EmployeeWork;
            employeeTrack.EmployeeWorkInfo = request.EmployeeWorkInfo;
            employeeTrack.Notes = request.Notes;

            await _employeeTracksRepository.UpdateAsync(employeeTrack);

            return Result.Success();

        }
    }
}
