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

namespace PSManagement.Application.Customers.UseCases.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : ICommandHandler<UpdateCustomerCommand, Result>
    {
        private readonly ICustomersRepository _customerRepository;
        private readonly IMapper _mapper;
        public UpdateCustomerCommandHandler(ICustomersRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task<Result> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {

            Customer customer = new (request.CustomerName ,_mapper.Map<Address>(request.Address),request.Email);
            customer.Id = request.CustomerId;

            await _customerRepository.UpdateAsync(customer);
            
            return Result.Ok();
        }
    }
}
