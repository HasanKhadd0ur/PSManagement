using Ardalis.Result;
using AutoMapper;
using PSManagement.Application.Customers.Common;
using PSManagement.Domain.Customers.DomainErrors;
using PSManagement.Domain.Customers.Entities;
using PSManagement.Domain.Customers.Repositories;
using PSManagement.Domain.Customers.Specification;
using PSManagement.SharedKernel.CQRS.Query;
using PSManagement.SharedKernel.Specification;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Customers.UseCases.Queries.GetCustomer
{
    public class GetCustomerQueryHandler : IQueryHandler<GetCustomerQuery, Result<CustomerDTO>>
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly IMapper _mapper;
        private readonly BaseSpecification<Customer> _specification ;
        public GetCustomerQueryHandler(ICustomersRepository customersRepository, IMapper mapper)
        {
            _customersRepository = customersRepository;
            _mapper = mapper;
            _specification = new CustomerSpecification();
        }

        public async Task<Result<CustomerDTO>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            Customer customer = await _customersRepository.GetByIdAsync(request.CustomerId,_specification);
            
            if (customer is null) {

                return Result.Invalid(CustomerErrors.InvalidEntryError);
            }

            return Result.Success(_mapper.Map<CustomerDTO>(customer));

        }
    }

}
