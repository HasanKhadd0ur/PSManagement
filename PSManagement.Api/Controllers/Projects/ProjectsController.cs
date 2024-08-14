using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PSManagement.Api.Controllers.ApiBase;
using PSManagement.Application.Projects.UseCases.Commands.AddAttachment;
using PSManagement.Application.Projects.UseCases.Commands.CreateProject;
using PSManagement.Application.Projects.UseCases.Queries.GetProject;
using PSManagement.Contracts.Projects.Requests;
using PSManagement.Contracts.Projects.Response;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ardalis.Result;
using PSManagement.Application.Projects.UseCases.Queries.ListAllProject;
using PSManagement.Application.Projects.UseCases.Commands.AddParticipant;
using PSManagement.Application.Projects.UseCases.Commands.RemoveParticipant;
using PSManagement.Application.Projects.UseCases.Commands.AddProjectStep;
using PSManagement.Application.Projects.UseCases.Commands.ChangeProjectTeamLeader;
using PSManagement.Application.Projects.UseCases.Commands.ApproveProject;
using PSManagement.Application.Projects.UseCases.Queries.GetParticipants;

namespace PSManagement.Api.Controllers.Projects
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : APIController
    {
        private readonly IMediator _sender;
        private readonly IMapper _mapper;

        public ProjectsController(IMapper mapper, IMediator sender)
        {
            _mapper = mapper;
            _sender = sender;
        }


        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]ListAllProjectsRequest request)
        {
            var query =  _mapper.Map<ListAllProjectsQuery>(request);

            var result = _mapper.Map<Result<IEnumerable<ProjectResponse>>>(await _sender.Send(query));

            return Ok(result);
        }


        [HttpGet("ByFilter")]
        public async Task<IActionResult> GetByFilter([FromQuery] GetProjectsByFilterRequest request)
        {
            GetProjectsByFilterQuery query = _mapper.Map<GetProjectsByFilterQuery>(request);

            var result = await _sender.Send(query);

            return Ok(_mapper.Map<Result<IEnumerable<ProjectResponse>>>(result));
        }

        [HttpGet("GetParticipants{id}")]
        public async Task<IActionResult> GetParticipants(int id)
        {
            GetProjectParticipantsQuery query = new (id);

            var result = await _sender.Send(query);

            return Ok( _mapper.Map<Result<IEnumerable<EmployeeParticipateResponse>>>(result));
        }

        [HttpPost("ApproveProject")]
        public async Task<IActionResult> ApproveProjectRequest(ApproveProjectRequest request)
        {
            var query = _mapper.Map<ApproveProjectCommand>(request);

            var result = await _sender.Send(query);

            return Ok(result);
        }

        [HttpPost("ChangeTeamLeader")]
        public async Task<IActionResult> ChangeTeamLeader(ChangeProjectTeamLeaderRequest request)
        {
            var query = _mapper.Map<ChangeProjectTeamLeaderCommand>(request);

            var result = await _sender.Send(query);

            return Ok(result);
        }


        [HttpPost("AddProjectStep")]
        public async Task<IActionResult> AddParticipant(AddProjectStepRequest request)
        {
            var query = _mapper.Map<AddProjectStepCommand>(request);

            var result = await _sender.Send(query);

            return Ok(result);
        }


        [HttpPost("RemoveParticipant")]
        public async Task<IActionResult> RemoveParticipant(RemoveParticipantRequest request)
        {
            var query = _mapper.Map<RemoveParticipantCommand>(request);

            var result = await _sender.Send(query);

            return Ok(result);
        }

        [HttpPost("AddParticipant")]
        public async Task<IActionResult> AddParticipant(AddParticipantRequest request)
        {
            var query = _mapper.Map<AddParticipantCommand>(request);

            var result = await _sender.Send(query);

            return Ok(result);
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetProjectByIdQuery(id);

            var result = await _sender.Send(query);

            return Ok(_mapper.Map<Result<ProjectResponse>>(result));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProjectRequest request)
        {
            var command = _mapper.Map<CreateProjectCommand>(request);
            var result = await _sender.Send(command);
            return Ok(_mapper.Map<CreateProjectResult>(result));
        
        }

        [HttpPost("AddAttachment")]
        public async Task<IActionResult> AddAttachment( [FromForm]AddAttachmentRequest request)
        {
            var command = _mapper.Map<AddAttachmentCommand>(request);
            var result = await _sender.Send(command);
            return Ok(result);

        }
    }
}
