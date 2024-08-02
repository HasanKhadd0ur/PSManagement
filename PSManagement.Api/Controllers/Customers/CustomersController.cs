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
using FluentResults;
using PSManagement.Application.Customers.UseCases.Queries.GetCustomer;

namespace PSManagement.Api.Controllers.Customers
{
    [Route("api/[controller]")]
    [ApiController]
  //  [Authorize]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _sender;
        private readonly IMapper _mapper;

        public CustomersController(IMediator sender, IMapper mapper )
        {
            _sender = sender;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ListCustomers()
        {
            var query = new ListAllCustomersQuery();

            var result = _mapper.Map<Result<IEnumerable<CustomerRecord>>>( await _sender.Send(query));
         
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id )
        {
            var query = new GetCustomerQuery(id);

            var result = _mapper.Map<Result<CustomerRecord>>(await _sender.Send(query));

            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CreateCustomerRequest request)
        {
            var command = _mapper.Map<CreateCustomerCommand>(request);

            var result = await _sender.Send(command);

            return Ok(result);
        }
        
        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer(DeleteCustomerRequest request)
        {
            var command = _mapper.Map<DeleteCustomerCommand>(request);

            var result = await _sender.Send(command);

            return Ok(result);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id ,UpdateCustomerRequest request)
        {
            if(id != request.CustomerId){
                return Problem();
            }
            var command = _mapper.Map<UpdateCustomerCommand>(request);

            var result = await _sender.Send(command);

            return Ok(result);

        }


        [HttpPost("AddContactInfo")]
        public async Task<IActionResult> AddContactInfo(AddContactInfoRequest request)
        {
            var command = _mapper.Map<AddContactInfoCommand>(request);

            var result = await _sender.Send(command);

            return Ok(result);
        }



    }
}
