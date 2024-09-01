using Ardalis.Result;
using PSManagement.Domain.Steps.Repositories;
using PSManagement.Domain.Tracking;
using PSManagement.Domain.Tracking.Entities;

using PSManagement.Domain.Tracking.DomainErrors;

using PSManagement.Domain.Tracking.Specification;
using PSManagement.SharedKernel.CQRS.Command;
using PSManagement.SharedKernel.Interfaces;

using PSManagement.SharedKernel.Specification;
using PSManagement.SharedKernel.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Tracks.UseCaes.Commands.RemoveTrack
{
    public class RemoveTrackCommandHandler : ICommandHandler<RemoveTrackCommand, Result>
    {
        private readonly ITracksRepository _tracksRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly BaseSpecification<Track> _specification;
        private readonly IRepository<StepTrack> _stepTracksRepository;

        private readonly IRepository<EmployeeTrack> _employeeTracksRepository;
        public RemoveTrackCommandHandler(
            IUnitOfWork unitOfWork,
            ITracksRepository tracksRepository,
            IRepository<StepTrack> stepTracksRepository,
            IRepository<EmployeeTrack> employeeTracksRepository
            )
        {

            _employeeTracksRepository=employeeTracksRepository;
            _stepTracksRepository = stepTracksRepository;
            _specification = new TrackSpecification();  
            _unitOfWork = unitOfWork;
            _tracksRepository = tracksRepository;
        }

        public async Task<Result> Handle(RemoveTrackCommand request, CancellationToken cancellationToken)
        {
            _specification.AddInclude(e => e.StepTracks);
            _specification.AddInclude(e => e.EmployeeTracks);

            Track track = await _tracksRepository.GetByIdAsync(request.TrackId,_specification);

            if (track is null)
            {

                return Result.Invalid(TracksErrors.InvalidEntryError);

            }

            foreach(var emp in track.EmployeeTracks){
                await _employeeTracksRepository.DeleteAsync(emp);
            }            
            
            foreach(var emp in track.StepTracks){
                await _stepTracksRepository.DeleteAsync(emp);
            }            
            
            await _tracksRepository.DeleteAsync(track);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();

        }
    }
}