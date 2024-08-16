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

namespace PSManagement.Application.Tracks.UseCaes.Commands.AddEmployeeTrack
{
    public class AddEmployeeTrackCommandHandler : ICommandHandler<AddEmployeeTrackCommand, Result<int>>
    {
        private readonly IRepository<EmployeeTrack> _employeeTracksRepository;
        private readonly ITracksRepository _tracksRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

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
        }

        public async Task<Result<int>> Handle(AddEmployeeTrackCommand request, CancellationToken cancellationToken)
        {
            Track track = await _tracksRepository.GetByIdAsync(request.TrackId);

            if (track is null)
            {

                return Result.Invalid(TracksErrors.InvalidEntryError);

            }

            EmployeeTrack employeeTrack = await _employeeTracksRepository.AddAsync(_mapper.Map<EmployeeTrack>(request));

            await _unitOfWork.SaveChangesAsync();

            return Result.Success(employeeTrack.Id);

        }
    }
}
