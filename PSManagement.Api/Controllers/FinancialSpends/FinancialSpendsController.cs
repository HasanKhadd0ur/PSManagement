using Ardalis.Result;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PSManagement.Api.Controllers.ApiBase;
using PSManagement.Application.FinancialSpends.UseCases.Commands.CreateFinancialSpendItem;
using PSManagement.Application.FinancialSpends.UseCases.Commands.RemoveFinancialSpendingItem;
using PSManagement.Application.FinancialSpends.UseCases.Commands.UpateFinancialSpendingItem;
using PSManagement.Application.FinancialSpends.UseCases.Queries.GetFinancialSpendingById;
using PSManagement.Application.FinancialSpends.UseCases.Queries.GetFinancialSpendingByProject;
using PSManagement.Contracts.FinancialSpends.Requests;
using PSManagement.Contracts.Projects.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSManagement.Api.Controllers.FinancialSpends
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinancialSpendsController : APIController
    {
        private readonly IMediator _sender;
        private readonly IMapper _mapper;

        public FinancialSpendsController(IMapper mapper, IMediator sender)
        {
            _mapper = mapper;
            _sender = sender;
        }


        [HttpPost]
        public async Task<IActionResult> Post(CreateFinancialSpendItemRequest request)
        {
            var command = _mapper.Map<CreateFinancialSpendItemCommand>(request);

            var result = await _sender.Send(command);

            if (result.IsSuccess)
            {

                var query = new GetFinancialSpendItemByIdQuery(result.Value);
                var response = await _sender.Send(query);

                return HandleResult(_mapper.Map<Result<FinancialSpendingResponse>>(response));

            }
            else
            {

                return HandleResult(result);

            }
        }

        [HttpGet]
        public async Task<IActionResult> Get( [FromQuery]GetFinancialSpendItemByIdRequest request)
        {
            var query = _mapper.Map<GetFinancialSpendItemByIdQuery>(request);

            var result = await _sender.Send(query);

            return HandleResult(_mapper.Map<Result<FinancialSpendingResponse>>(result)); ;
        }

        [HttpGet("GetByProject")]
        public async Task<IActionResult> GetByProject([FromQuery] GetFinancialSpendItemByProjecRequest request)
        {
            var query = _mapper.Map<GetFinancialSpendItemByProjectQuery>(request);

            var result = await _sender.Send(query);

            return HandleResult(_mapper.Map<Result<IEnumerable<FinancialSpendingResponse>>>(result)); ;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete( RemoveFinancialSpendItemRequest request,[FromRoute]int id)
        {
            if (id != request.Id) {
                Result.Conflict();
            }

            var query = _mapper.Map<RemoveFinancialSpendItemCommand>(request);

            var result = await _sender.Send(query);

            return HandleResult(result); ;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(UpdateFinancialSpendItemRequest request, [FromRoute] int id)
        {
            if (id != request.Id)
            {
                Result.Conflict("no match for the id");
            }

            var query = _mapper.Map<UpdateFinancialSpendItemCommand>(request);

            var result = await _sender.Send(query);

            return HandleResult(result); ;
        }

    }
}
