using Ardalis.Result;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PSManagement.Api.Controllers.ApiBase;
using PSManagement.Application.ProjectsTypes.UseCases.Commands.CreateNewType;
using PSManagement.Application.ProjectsTypes.UseCases.Queries.GetProjectsTypes;
using PSManagement.Application.ProjectsTypes.UseCases.Queries.GetTypeById;
using PSManagement.Contracts.ProjectsTypes.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsTypesController : APIController
    {
        private readonly IMediator _sender;
        private readonly IMapper _mapper;

        public ProjectsTypesController(IMediator sender, IMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetProjectsTypesQuery();

            var result = _mapper.Map<Result<IEnumerable<ProjectTypeResponse>>>(await _sender.Send(query));

            return HandleResult(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetTypeByIdQuery(id);

            var result = await _sender.Send(query);


            return HandleResult(_mapper.Map<Result<ProjectTypeResponse>>(result));
        }


        [HttpPost]
        public async Task<IActionResult> Post(CreateNewTypeRequest request)
        {
            var command = _mapper.Map<CreateNewTypeCommand>(request);

            var result = await _sender.Send(command);

            if (result.IsSuccess)
            {

                var query = new GetTypeByIdQuery(result.Value);

                var response = await _sender.Send(query);

                return HandleResult(_mapper.Map<Result<ProjectTypeResponse>>(response));

            }
            else
            {

                return HandleResult(result);

            }

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new RemoveTypeCommand(id);

            var result = await _sender.Send(command);

            return HandleResult(result);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateTypeCommand request)
        {
            if (id != request.Id)
            {
                return Problem();
            }
            var command = _mapper.Map<UpdateTypeCommand>(request);

            var result = await _sender.Send(command);

            return HandleResult(result);

        }


    }
}
