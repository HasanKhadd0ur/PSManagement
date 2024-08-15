using Ardalis.Result;
using AutoMapper;
using PSManagement.Application.FinancialSpends.Common;
using PSManagement.Domain.FinancialSpends.Entities;
using PSManagement.Domain.FinincialSpending.Repositories;
using PSManagement.SharedKernel.CQRS.Query;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.FinancialSpends.UseCases.Queries.GetFinancialSpendingById
{
    public class GetFinancialSpendItemByIdQueryHandler : IQueryHandler<GetFinancialSpendItemByIdQuery, Result<FinancialSpendingDTO>>
    {
        private readonly IFinancialSpendingRepository _spendRepository;
        private readonly IMapper _mapper;

        public GetFinancialSpendItemByIdQueryHandler(
            IMapper mapper,
            IFinancialSpendingRepository spendRepository
            )
        {
            _mapper = mapper;
            _spendRepository = spendRepository;
        }

        public async Task<Result<FinancialSpendingDTO>> Handle(GetFinancialSpendItemByIdQuery request, CancellationToken cancellationToken)
        {
            
            FinancialSpending spending = await _spendRepository.GetByIdAsync(request.Id);
            if (spending is null) {
                return Result.NotFound("Not Found");
            }
            return Result.Success(_mapper.Map<FinancialSpendingDTO>(spending));


       }
    }
}

