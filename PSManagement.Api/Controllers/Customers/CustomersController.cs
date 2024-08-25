using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using PSManagement.Contracts.Customers.Requests;
using PSManagement.Application.Customers.UseCases.Commands.CreateCustomer;
using PSManagement.Domain.Customers.ValueObjects;
using AutoMapper;
using PSManagement.Application.Customers.UseCases.Commands.AddContactInfo;
using PSManagement.Application.Customers.UseCases.Commands.DeleteCustomer;
using PSManagement.Application.Customers.UseCases.Commands.UpdateCustomer;
using PSManagement.Application.Customers.UseCases.Queries.ListAllCustomers;
using PSManagement.Contracts.Customers.Responses;
using PSManagement.Application.Customers.UseCases.Queries.GetCustomer;
using PSManagement.Api.Controllers.ApiBase;
using Ardalis.Result;
using PSManagement.Application.Customers.UseCases.Commands.RemoveContactInfo;

namespace PSManagement.Api.Controllers.Customers
{
    [Route("api/[controller]")]
    [Authorize]
    public class CustomersController : APIController
    {
        private readonly IMediator _sender;
        private readonly IMapper _mapper;

        public CustomersController(IMediator sender, IMapper mapper )
        {
            _sender = sender;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new ListAllCustomersQuery();

            var result = _mapper.Map<Result<IEnumerable<CustomerResponse>>>( await _sender.Send(query));
         
            return HandleResult(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id )
        {
            var query = new GetCustomerQuery(id);

            var result = await _sender.Send(query);


            return HandleResult(_mapper.Map<Result<CustomerResponse>>(result));
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateCustomerRequest request)
        {
            var command = _mapper.Map<CreateCustomerCommand>(request);

            var result = await _sender.Send(command);

            if (result.IsSuccess)
            {

                var query = new GetCustomerQuery(result.Value);

                var response = await _sender.Send(query);

                return HandleResult(_mapper.Map<Result<CustomerResponse>>(response));

            }
            else
            {

                return HandleResult(result);

            }

        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteCustomerCommand(id);

            var result = await _sender.Send(command);

            return HandleResult(result);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id ,UpdateCustomerRequest request)
        {
            if(id != request.CustomerId){
                return Problem();
            }
            var command = _mapper.Map<UpdateCustomerCommand>(request);

            var result = await _sender.Send(command);

            return HandleResult(result);

        }


        [HttpPost("AddContactInfo")]
        public async Task<IActionResult> PostContactInfo(AddContactInfoRequest request)
        {
            var command = _mapper.Map<AddContactInfoCommand>(request);

            var result = await _sender.Send(command);

            return HandleResult(result);
        }


        [HttpDelete("RemoveContactInfo")]
        public async Task<IActionResult> DeleteContactInfo(RemoveContactInfoRequest request)
        {
            var command = _mapper.Map<RemoveContactInfoCommand>(request);

            var result = await _sender.Send(command);

            return HandleResult(result);
        }


    }
}
