using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PSManagement.Api.Controllers.ApiBase;
using PSManagement.Application.Projects.UseCases.Commands.AddAttachment;
using PSManagement.Application.Projects.UseCases.Commands.CreateProject;
using PSManagement.Contracts.Projects.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
