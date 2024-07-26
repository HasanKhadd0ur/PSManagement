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

namespace PSManagement.Api.Controllers.Customers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomersController : ControllerBase
    {
        private readonly ISender _sender;

        public CustomersController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(Guid userId, Guid subscriptionId, CreateCustomerRequest request)
        {
            Address address = new Address(request.City,request.StreetName,request.ZipCode,request.StreetNumber);
            var command = new CreateCustomerCommand(request.CustomerName,address);

            var result = await _sender.Send(command);

            return result;
        }
    }
}
