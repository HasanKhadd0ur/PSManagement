using Ardalis.Result;
using AutoMapper;
using PSManagement.Domain.Steps.Repositories;
using PSManagement.Domain.Tracking;
using PSManagement.Domain.Tracking.DomainErrors;
using PSManagement.Domain.Tracking.Specification;
using PSManagement.SharedKernel.CQRS.Command;
using PSManagement.SharedKernel.Interfaces;
using PSManagement.SharedKernel.Repositories;
using PSManagement.SharedKernel.Specification;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace PSManagement.Application.Tracks.UseCaes.Commands.AddEmployeeTrack
{
    public class AddEmployeeTrackCommandHandler : ICommandHandler<AddEmployeeTrackCommand, Result<int>>
    {
        private readonly IRepository<EmployeeTrack> _employeeTracksRepository;
        private readonly ITracksRepository _tracksRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly BaseSpecification<Track> _specification;

        public AddEmployeeTrackCommandHandler(
            IUnitOfWork unitOfWork,
            ITracksRepository tracksRepository,
            IRepository<EmployeeTrack> employeeTracksRepository,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _tracksRepository = tracksRepository;
            _employeeTracksRepository = employeeTracksRepository;
            _mapper = mapper;
            _specification = new TrackSpecification();
        }

        public async Task<Result<int>> Handle(AddEmployeeTrackCommand request, CancellationToken cancellationToken)
        {
            _specification.AddInclude(e => e.EmployeeTracks);
            Track track = await _tracksRepository.GetByIdAsync(request.TrackId,_specification);

            if (track is null)
            {

                return Result.Invalid(TracksErrors.InvalidEntryError);

            }

            if (track.TrackInfo.IsCompleted)
            {

                return Result.Invalid(TracksErrors.TrackCompletedUpdateError);
            }

            if (track.EmployeeTracks.Any(e => e.EmployeeId == request.EmployeeId)) {

                return Result.Invalid(TracksErrors.ParticipantTrackExistError);
            
            }
            var r =_mapper.Map<EmployeeTrack>(request);
            //Console.WriteLine(r.EmloyeeId);
            EmployeeTrack employeeTrack = await _employeeTracksRepository.AddAsync(_mapper.Map<EmployeeTrack>(request));

            await _unitOfWork.SaveChangesAsync();

            return Result.Success(employeeTrack.Id);

        }
    }
}
