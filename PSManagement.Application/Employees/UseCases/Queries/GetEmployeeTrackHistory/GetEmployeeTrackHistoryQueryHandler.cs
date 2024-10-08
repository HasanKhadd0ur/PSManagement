﻿using Ardalis.Result;
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
using System ;
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
            _specification.ApplyOptionalPagination(request.PageSize, request.PageNumber);
            _specification.AddInclude(e => e.Track);
            _specification.AddInclude(e => e.Employee);
            _specification.AddInclude(e => e.Employee.User);

            _specification.Criteria = e => e.EmployeeId == request.EmployeeId  && e.Track.ProjectId == request.ProjectId;
            
            IEnumerable<EmployeeTrack> employeeTracks = await _employeeTracksRepository.ListAsync( _specification);

            return Result.Success(_mapper.Map<IEnumerable<EmployeeTrackDTO>>(employeeTracks));
        }
    }
}
