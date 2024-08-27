using Ardalis.Result;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
using PSManagement.Contracts.Tracks.Response;
using PSManagement.Presentation.Controllers.ApiBase;
using PSManagement.Application.Steps.UseCases.Commands.UpdateStepInformaion;

namespace PSManagement.Presentation.Controllers.Steps
{
    [Route("api/[controller]")]
    public class StepsController : APIController
    {
        #region Dependency 
        private readonly IMapper _mapper;
        private readonly IMediator _sender;
        #endregion Dependency 

        #region Constructors
        public StepsController(IMediator sender, IMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
        }
        #endregion Constructors

        #region Queries

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetStepByIdQuery(id);

            var result = _mapper.Map<Result<StepResponse>>(await _sender.Send(query));

            return HandleResult(result);
        }

        [HttpGet("ByProject")]
        public async Task<IActionResult> GetByProject([FromQuery] GetStepsByProjectRequest request)
        {
            GetStepsByProjectQuery query = _mapper.Map<GetStepsByProjectQuery>(request);

            var result = _mapper.Map<Result<IEnumerable<StepResponse>>>(await _sender.Send(query));

            return HandleResult(result);
        }

        #endregion Queries

        #region Update 

        [HttpPut("ChangeStepWeight/{id}")]
        public async Task<IActionResult> PutChangeStepWeight(ChangeStepWeightRequest request, [FromRoute] int id)
        {
            if (request.StepId != id)
            {
                return HandleResult(Result.NotFound("the step not found"));
            }
            var query = _mapper.Map<ChangeStepWeightCommand>(request); ;

            var result = await _sender.Send(query);

            return HandleResult(result);
        }

        [HttpPut("UpdateStepInfo/{id}")]
        public async Task<IActionResult> PutChangeStepInfo(ChangeStepInfoRequest request )
        {

            var query = _mapper.Map<UpdateStepInformationCommand>(request); ;

            var result = _mapper.Map<Result>(await _sender.Send(query));

            return HandleResult(result);
        }

        [HttpPut("ChangeCompletionRatio/{id}")]
        public async Task<IActionResult> PutCompletionRatio(UpdateCompletionRatioRequest request)
        {
            var query = _mapper.Map<UpdateCompletionRatioCommand>(request);

            var result = _mapper.Map<Result>(await _sender.Send(query));

            return HandleResult(result);
        }

        #endregion Update 

        #region Track History 

        [HttpGet("StepTrackHistory")]
        public async Task<IActionResult> Get([FromQuery] GetStepTrackHistoryRequest request)
        {
            var query = _mapper.Map<GetStepTrackHistoryQuery>(request);

            var result = _mapper.Map<Result<IEnumerable<StepTrackResponse>>>(await _sender.Send(query));

            return HandleResult(result);
        }

        #endregion Track History 

        #region Delete 
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var query = new RemoveStepCommand(id);

            var result = await _sender.Send(query);

            return HandleResult(result);
        }
        #endregion Delete 
    }
}
