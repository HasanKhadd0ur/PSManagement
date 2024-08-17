using Ardalis.Result;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PSManagement.Api.Controllers.ApiBase;
using PSManagement.Application.Tracks.UseCaes.Commands.AddEmployeeTrack;
using PSManagement.Application.Tracks.UseCaes.Commands.AddStepTrack;
using PSManagement.Application.Tracks.UseCaes.Commands.CompleteTrack;
using PSManagement.Application.Tracks.UseCaes.Commands.CreateTrack;
using PSManagement.Application.Tracks.UseCaes.Commands.RemoveTrack;
using PSManagement.Application.Tracks.UseCaes.Commands.UpdateEmployeeWorkTrack;
using PSManagement.Application.Tracks.UseCaes.Commands.UpdateStepTrack;
using PSManagement.Application.Tracks.UseCaes.Queries.GetEmployeesTrack;
using PSManagement.Application.Tracks.UseCaes.Queries.GetStepsTrack;
using PSManagement.Application.Tracks.UseCaes.Queries.GetTrackById;
using PSManagement.Application.Tracks.UseCaes.Queries.GetTracksByProject;
using PSManagement.Contracts.Tracks.Requests;
using PSManagement.Contracts.Tracks.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PSManagement.Api.Controllers.Tracks
{
    [Route("api/[controller]")]
    public class TracksController : APIController
    {

        private readonly IMapper _mapper;
        private readonly IMediator _sender;

        public TracksController(IMediator sender, IMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetTrackByIdQuery(id);

            var result = _mapper.Map<Result<TrackResponse>>(await _sender.Send(query));

            return Ok(result);
        }

        [HttpGet("GetStepsTrack{id}")]
        public async Task<IActionResult> GetStepsTrack([FromRoute]int id)
        {
            var query = new GetStepsTrackQuery(id);

            var result = _mapper.Map<Result<IEnumerable<StepTrackResponse>>>(await _sender.Send(query));

            return Ok(result);
        }

        [HttpGet("GetEmployeesTrack{id}")]
        public async Task<IActionResult> GetEmployeesTrack([FromRoute] int id)
        {
            var query = new GetEmployeesTrackQuery(id);

            var result = _mapper.Map<Result<IEnumerable<EmployeeTrackResponse>>>(await _sender.Send(query));

            return Ok(result);

        }

        [HttpGet("GetTracksByProject")]
        public async Task<IActionResult> GetTracksByProject([FromQuery] GetTracksByProjectRequest request)
        {
            var query = _mapper.Map<GetTracksByProjectQuery>(request);

            var result = _mapper.Map<Result<IEnumerable<TrackResponse>>>(await _sender.Send(query));

            return Ok(result);
        }

        [HttpPost("AddStepTrack")]
        public async Task<IActionResult>PostStepTrack(AddStepTrackRequest request)
        {
            var command = _mapper.Map<AddStepTrackCommand>(request);

            var result = _mapper.Map<Result<int>>(await _sender.Send(command));

            return Ok(result);
        }

        [HttpPost("AddEmployeeTrack")]
        public async Task<IActionResult> PostEmployeeTrack(AddEmployeeTrackRequest request)
        {
            var command = _mapper.Map<AddEmployeeTrackCommand>(request);

            var result = _mapper.Map<Result<int>>(await _sender.Send(command));

            return Ok(result);
        }

        [HttpPost("CompleteTrack")]
        public async Task<IActionResult> PostCompleteTrack(CompleteTrackRequest request)
        {
            var command = _mapper.Map<CompleteTrackCommand>(request);

            var result =await _sender.Send(command);

            return Ok(result);
        }

        [HttpPost("RemoveTrack")]
        public async Task<IActionResult> PostRemoveTrack(RemoveTrackRequest request)
        {
            var command = _mapper.Map<RemoveTrackCommand>(request);

            var result =await _sender.Send(command);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostCreateTrack(CreateTrackRequest request)
        {
            var command = _mapper.Map<CreateTrackCommand>(request);

            var result = _mapper.Map<Result<int>>(await _sender.Send(command));

            if (result.IsSuccess)
            {

                var query = new GetTrackByIdQuery(result.Value);
                var response = await _sender.Send(query);

                return Ok(_mapper.Map<TrackResponse>(response));

            }
            else
            {

                return Ok(result);

            }
        }

        [HttpPut("UpdateEmployeeWorkTrack")]
        public async Task<IActionResult> PutEmployeeWorkTrack(UpdateEmployeeWorkTrackRequest request)
        {
            var command = _mapper.Map<UpdateEmployeeWorkTrackCommand>(request);

            var result =await _sender.Send(command);

            return Ok(result);
        }
        [HttpPut("UpdateStepTrack")]
        public async Task<IActionResult> PutStepTrack(UpdateStepTrackRequest request)
        {
            var command = _mapper.Map<UpdateStepTrackCommand>(request);

            var result = await _sender.Send(command);

            return Ok(result);
        }


    }
}
