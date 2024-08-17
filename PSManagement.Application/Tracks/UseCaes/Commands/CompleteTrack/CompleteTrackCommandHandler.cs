using Ardalis.Result;
using AutoMapper;
using PSManagement.Domain.Employees.Repositories;
using PSManagement.Domain.Projects.Entities;
using PSManagement.Domain.Projects.Repositories;
using PSManagement.Domain.Steps.Repositories;
using PSManagement.Domain.Tracking;
using PSManagement.Domain.Tracking.DomainErrors;
using PSManagement.Domain.Tracking.DomainEvents;
using PSManagement.Domain.Tracking.Entities;
using PSManagement.Domain.Tracking.Specification;
using PSManagement.SharedKernel.CQRS.Command;
using PSManagement.SharedKernel.Interfaces;
using PSManagement.SharedKernel.Specification;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Tracks.UseCaes.Commands.CompleteTrack
{
    public class CompleteTrackCommandHandler : ICommandHandler<CompleteTrackCommand, Result>
    {
        private readonly ITracksRepository _tracksRepository;
        private readonly IStepsRepository _stepsRepository;
        private readonly IEmployeesRepository _employeesRepository;

        private readonly IUnitOfWork _unitOfWork;
        private readonly BaseSpecification<Track> _specification;

        public CompleteTrackCommandHandler(
            IUnitOfWork unitOfWork,
            ITracksRepository tracksRepository,
            IStepsRepository stepsRepository,
            IEmployeesRepository employeesRepository)
        {

            _unitOfWork = unitOfWork;
            _specification = new TrackSpecification();
            _tracksRepository = tracksRepository;
            _stepsRepository = stepsRepository;
            _employeesRepository = employeesRepository;
        }

        public async Task<Result> Handle(CompleteTrackCommand request, CancellationToken cancellationToken)
        {
            _specification.AddInclude(e => e.StepTracks);
            _specification.AddInclude(e => e.EmployeeTracks);

            _specification.AddInclude("EmployeeTracks.Employee");

            Track track = await _tracksRepository.GetByIdAsync(request.TrackId,_specification);

            if (track is null)
            {

                return Result.Invalid(TracksErrors.InvalidEntryError);

            }

            foreach (StepTrack stepTrack in track?.StepTracks) {

                Step step =await _stepsRepository.GetByIdAsync(stepTrack.StepId);

                step.CurrentCompletionRatio += stepTrack.TrackExecutionRatio;
            
            }

            track.Complete(request.CompletionDate);
            await _unitOfWork.SaveChangesAsync();

            return Result.Success();

        }
    }
}
