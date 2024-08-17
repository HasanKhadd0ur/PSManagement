using Ardalis.Result;
using AutoMapper;
using PSManagement.Application.Tracks.Common;
using PSManagement.Domain.Tracking;
using PSManagement.Domain.Tracking.Specification;
using PSManagement.SharedKernel.CQRS.Query;
using PSManagement.SharedKernel.Repositories;
using PSManagement.SharedKernel.Specification;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Employees.UseCases.Queries.GetEmployeeTrackHistory
{
    public class GetEmployeeTrackHistoryQueryHandler : IQueryHandler<GetEmployeeTrackHistoryQuery, Result<IEnumerable<EmployeeTrackDTO>>>
    {
        private readonly IRepository<EmployeeTrack> _employeeTracksRepository;
        private readonly BaseSpecification<EmployeeTrack> _specification;
        private readonly IMapper _mapper;

        public GetEmployeeTrackHistoryQueryHandler(
            IMapper mapper,
            IRepository<EmployeeTrack> employeeTracksRepository)
        {
            _specification = new EmployeeTrackSpecification();
            _mapper = mapper;
            _employeeTracksRepository = employeeTracksRepository;
        }

        public async Task<Result<IEnumerable<EmployeeTrackDTO>>> Handle(GetEmployeeTrackHistoryQuery request, CancellationToken cancellationToken)
        {
            int pageNumber = request.PageNumber.HasValue && request.PageNumber.Value > 0 ? request.PageNumber.Value : 1;
            int pageSize = request.PageSize.HasValue && request.PageSize.Value > 0 && request.PageSize.Value <= 30 ? request.PageSize.Value : 30;
            _specification.AddInclude(e => e.Track);
            _specification.AddInclude(e => e.Employee);
            _specification.Criteria = e => e.EmloyeeId == request.EmployeeId  && e.Track.ProjectId == request.ProjectId;
            _specification.ApplyPaging((pageNumber - 1) * pageSize, pageSize);

            IEnumerable<EmployeeTrack> employeeTracks = await _employeeTracksRepository.ListAsync( _specification);

            return Result.Success(_mapper.Map<IEnumerable<EmployeeTrackDTO>>(employeeTracks));
        }
    }
}
