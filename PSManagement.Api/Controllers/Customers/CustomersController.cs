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

namespace PSManagement.Api.Controllers.Customers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _sender;
        private readonly IMapper _mapper;

        public CustomersController(IMediator sender, IMapper mapper )
        {
            _sender = sender;
            _mapper = mapper;
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
        [HttpPut]
        public async Task<IActionResult> UpdateCustomer(UpdateCustomerRequest request)
        {
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
