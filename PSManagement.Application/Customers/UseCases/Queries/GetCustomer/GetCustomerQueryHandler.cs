using AutoMapper;
using FluentResults;
using PSManagement.Application.Customers.Common;
using PSManagement.Domain.Customers.Aggregate;
using PSManagement.Domain.Customers.DomainErrors;
using PSManagement.Domain.Customers.Repositories;
using PSManagement.SharedKernel.CQRS.Query;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Customers.UseCases.Queries.GetCustomer
{
    public class GetCustomerQueryHandler : IQueryHandler<GetCustomerQuery, Result<CustomerDTO>>
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly IMapper _mapper;
        public GetCustomerQueryHandler(ICustomersRepository customersRepository, IMapper mapper)
        {
            _customersRepository = customersRepository;
            _mapper = mapper;
        }

        public async Task<Result<CustomerDTO>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            Customer customer = await _customersRepository.GetByIdAsync(request.customerId);
            if (customer is null) {
                return Result.Fail(CustomerErrors.InvalidEntryError);
            }
            return Result.Ok(_mapper.Map<CustomerDTO>(customer));

        }
    }

}
