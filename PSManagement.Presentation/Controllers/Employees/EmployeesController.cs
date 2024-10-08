﻿using Ardalis.Result;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PSManagement.Application.Contracts.Providers;
using PSManagement.Application.Contracts.SyncData;
using PSManagement.Application.Employees.UseCases.Commands.UpdateEmployeeWorkHours;
using PSManagement.Application.Employees.UseCases.Queries.GetAvailableEmployees;
using PSManagement.Application.Employees.UseCases.Queries.GetDepartments;
using PSManagement.Application.Employees.UseCases.Queries.GetEmployeeById;
using PSManagement.Application.Employees.UseCases.Queries.GetEmployeesByFilter;
using PSManagement.Application.Employees.UseCases.Queries.GetEmployeeTrackHistory;
using PSManagement.Contracts.Employees.Requests;
using PSManagement.Contracts.Projects.Response;
using PSManagement.Contracts.Tracks.Response;
using PSManagement.Presentation.Controllers.ApiBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSManagement.Presentation.Controllers.Employees
{
    [Route("api/[controller]")]
    public class EmployeesController : APIController
    {
        private readonly ISyncEmployeesService _syncEmployeesService;
        private readonly IEmployeesProvider _employeesProvider;
        private readonly IMediator _sender;
        private readonly IMapper _mapper;

        #region Constructors 
        public EmployeesController(
            ISyncEmployeesService syncEmployeesService,
            IMapper mapper,
            IMediator sender,
            IEmployeesProvider employeesProvider)
        {
            _syncEmployeesService = syncEmployeesService;
            _mapper = mapper;
            _sender = sender;
            _employeesProvider = employeesProvider;
        }
        #endregion Constructors 

        #region Get Requests 

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetEmployeeByIdQuery(id);

            var result = await _sender.Send(query);

            return HandleResult(_mapper.Map<Result<EmployeeResponse>>(result));
        }

        [HttpGet("ByFilter")]
        public async Task<IActionResult> GetByFilter([FromQuery] GetEmployeesByFilterRequest request)
        {
            GetEmployeesByFilterQuery query = _mapper.Map<GetEmployeesByFilterQuery>(request);

            var result = await _sender.Send(query);

            return HandleResult(_mapper.Map<Result<IEnumerable<EmployeeResponse>>>(result));
        }

        [HttpGet("Available")]
        public async Task<IActionResult> GetAllAvailable([FromQuery] GetAvailableEmployeesRequest request)
        {
            GetAvailableEmployeesQuery query = _mapper.Map<GetAvailableEmployeesQuery>(request);

            var result = await _sender.Send(query);

            return HandleResult(_mapper.Map<Result<IEnumerable<EmployeeResponse>>>(result));
        }

        [HttpGet("GetDepartments")]
        public async Task<IActionResult> GetDepartments()
        {
            var query = new GetDepartmentsQuery();

            var result = await _sender.Send(query);

            return HandleResult(_mapper.Map<Result<IEnumerable<DepartmentResponse>>>(result));

        }


        [HttpGet("EmployeeParticipations")]
        public async Task<IActionResult> GetEmployeeParticipations([FromQuery] GetEmployeeParticipationRequest request)
        {
            var command = _mapper.Map<GetEmployeeParticipationQuery>(request);
            var result = await _sender.Send(command);

            return HandleResult(_mapper.Map<Result<IEnumerable<EmployeeParticipateResponse>>>(result));

        }

        [HttpGet("TrackHistory")]
        public async Task<IActionResult> GetEmployeeTrackHistory([FromQuery] GetEmployeeTrackHistoryRequest request)
        {
            var command = _mapper.Map<GetEmployeeTrackHistoryQuery>(request);
            var result = await _sender.Send(command);

            return HandleResult(_mapper.Map<Result<IEnumerable<EmployeeTrackResponse>>>(result));

        }

        #endregion Get Requests

        #region Post Requests 
        [HttpPost("SyncEmployees")]
        public async Task<IActionResult> Post()
        {

            SyncResponse response = await _syncEmployeesService.SyncEmployees(_employeesProvider);
            return Ok(response);

        }

        #endregion Post Requests

        #region Put Request 
        [HttpPut("UpdateWorkHours")]
        public async Task<IActionResult> PutUpdateWorkHours(UpdateEmployeeWorkHoursRequest request)
        {
            UpdateEmployeeWorkHoursCommand query = _mapper.Map<UpdateEmployeeWorkHoursCommand>(request);

            var result = await _sender.Send(query);

            return HandleResult(result);

        }
        #endregion Put Requests

    }
}
