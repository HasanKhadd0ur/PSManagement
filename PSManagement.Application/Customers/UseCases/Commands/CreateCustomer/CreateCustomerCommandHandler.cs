using AutoMapper;
using FluentResults;
using PSManagement.Domain.Customers.Aggregate;
using PSManagement.Domain.Customers.DomainEvents;
using PSManagement.Domain.Customers.Repositories;
using PSManagement.Domain.Customers.ValueObjects;
using PSManagement.SharedKernel.CQRS.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Customers.UseCases.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : ICommandHandler<CreateCustomerCommand, Result<int>>
    {
        private readonly ICustomersRepository _customerRepository;
        
        public CreateCustomerCommandHandler(ICustomersRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<Result<int>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {

            Customer customer = new (request.CustomerName ,request.Address,request.Email);

            customer =await _customerRepository.AddAsync(customer);
            
            customer.AddDomainEvent(new CutsomerCreatedEvent(customer.Id ,customer.CustomerName));


            return Result.Ok(customer.Id);
        }
    }
}
