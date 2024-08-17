using Ardalis.Result;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PSManagement.Api.Controllers.ApiBase;
using PSManagement.Application.Steps.UseCases.Commands.ChangeStepWeight;
using PSManagement.Application.Steps.UseCases.Commands.RemoveStep;
using PSManagement.Application.Steps.UseCases.Commands.UpdateCompletionRatio;
using PSManagement.Application.Steps.UseCases.Queries.GetStepById;
using PSManagement.Application.Steps.UseCases.Queries.GetStepsByProject;
using PSManagement.Application.Steps.UseCases.Queries.GetStepTrackHistory;
using PSManagement.Contracts.Projects.Response;
using PSManagement.Contracts.Steps.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSManagement.Api.Controllers.Steps
{
    [Route("api/[controller]")]
    public class StepsController : APIController
    {
        private readonly IMapper _mapper;
        private readonly IMediator _sender;

        public StepsController(IMediator sender, IMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id )
        {
            var query = new GetStepByIdQuery(id) ;

            var result = _mapper.Map<Result<StepResponse>>(await _sender.Send(query));

            return Ok(result);
        }

        [HttpGet("ByProject")]
        public async Task<IActionResult> GetByProject([FromQuery] GetStepsByProjectRequest request)
        {
            GetStepsByProjectQuery query = _mapper.Map<GetStepsByProjectQuery>(request);

            var result = _mapper.Map<Result<IEnumerable<StepResponse>>>(await _sender.Send(query));

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutChangeStepWeight(ChangeStepWeightRequest request,[FromRoute]int id)
        {
            if (request.StepId != id) {
                return Ok(Result.NotFound("the step not found"));
            }
            var query =  _mapper.Map<ChangeStepWeightCommand>(request); ;

            var result = _mapper.Map<Result>(await _sender.Send(query));

            return Ok(result);
        }


        [HttpGet("StepTrackHistory")]
        public async Task<IActionResult> Get([FromQuery] GetStepTrackHistoryRequest request)
        {
            var query =_mapper.Map<GetStepTrackHistoryQuery>(request);

            var result = _mapper.Map<Result<IEnumerable<StepTrackResponse>>>(await _sender.Send(query));

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> PutCompletionRatio(UpdateCompletionRatioRequest request)
        {
            var query = _mapper.Map<UpdateCompletionRatioCommand>(request);

            var result = _mapper.Map<Result>(await _sender.Send(query));

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            var query = new RemoveStepCommand(id);

            var result = _mapper.Map<Result>(await _sender.Send(query));

            return Ok(result);
        }
    }
}
