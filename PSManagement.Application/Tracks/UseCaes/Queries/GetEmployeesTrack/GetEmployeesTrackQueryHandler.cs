using Ardalis.Result;
using AutoMapper;
using PSManagement.Application.Tracks.Common;
using PSManagement.Domain.Steps.Repositories;
using PSManagement.Domain.Tracking;
using PSManagement.Domain.Tracking.DomainErrors;
using PSManagement.Domain.Tracking.Specification;
using PSManagement.SharedKernel.CQRS.Query;
using PSManagement.SharedKernel.Repositories;
using PSManagement.SharedKernel.Specification;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Tracks.UseCaes.Queries.GetEmployeesTrack
{
    public class GetEmployeesTrackQueryHandler : IQueryHandler<GetEmployeesTrackQuery, Result<IEnumerable<EmployeeTrackDTO>>>
    {
        private readonly ITracksRepository _tracksRepository;
        private readonly IRepository<EmployeeTrack> _employeeTracksRepository;
        private readonly IMapper _mapper;
        private readonly BaseSpecification<EmployeeTrack> _specification;
        public GetEmployeesTrackQueryHandler(
            IMapper mapper,
            ITracksRepository tracksRepository,
            IRepository<EmployeeTrack> employeeTracksRepository
            )
        {
            _mapper = mapper;
            _tracksRepository = tracksRepository;
            _specification = new EmployeeTrackSpecification();
            _employeeTracksRepository = employeeTracksRepository;
        }


        public async Task<Result<IEnumerable<EmployeeTrackDTO>>> Handle(GetEmployeesTrackQuery request, CancellationToken cancellationToken)
        {



            _specification.Criteria = t => t.TrackId == request.TrackId;
            _specification.AddInclude(e => e.Employee);


            var track = await _tracksRepository.GetByIdAsync(request.TrackId);
            if (track is null)
            {
                return Result.Invalid(TracksErrors.InvalidEntryError);
            }
            else
            {

                IEnumerable<EmployeeTrack> employeeTracks = await _employeeTracksRepository.ListAsync(_specification);
                employeeTracks = employeeTracks.Select(eTrack => { eTrack.Track = track; return eTrack; });

                return Result.Success(_mapper.Map<IEnumerable<EmployeeTrackDTO>>(employeeTracks));

            }

        }
    }
}
