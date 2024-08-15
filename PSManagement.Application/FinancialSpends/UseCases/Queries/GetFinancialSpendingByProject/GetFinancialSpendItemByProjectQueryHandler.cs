using Ardalis.Result;
using AutoMapper;
using PSManagement.Application.FinancialSpends.Common;
using PSManagement.Domain.FinancialSpends.Entities;
using PSManagement.Domain.FinancialSpends.Specification;
using PSManagement.Domain.FinincialSpending.Repositories;
using PSManagement.SharedKernel.CQRS.Query;
using PSManagement.SharedKernel.Specification;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.FinancialSpends.UseCases.Queries.GetFinancialSpendingByProject
{
    public class GetFinancialSpendItemByProjectQueryHandler : IQueryHandler<GetFinancialSpendItemByProjectQuery, Result<IEnumerable<FinancialSpendingDTO>>>
    {
        private readonly IFinancialSpendingRepository _spendRepository;
        private readonly IMapper _mapper;
        private readonly BaseSpecification<FinancialSpending> _specification;

        public GetFinancialSpendItemByProjectQueryHandler(
            IMapper mapper,
            IFinancialSpendingRepository spendRepository)
        {
            _mapper = mapper;
            _spendRepository = spendRepository;
            _specification = new FinancialSpendingSpecification();

        }

        public async Task<Result<IEnumerable<FinancialSpendingDTO>>> Handle(GetFinancialSpendItemByProjectQuery request, CancellationToken cancellationToken)
        {
            _specification.Criteria = p => p.ProjectId == request.ProjectId;

            int pageNumber = request.PageNumber.HasValue && request.PageNumber.Value > 0 ? request.PageNumber.Value : 1;
            int pageSize = request.PageSize.HasValue && request.PageSize.Value > 0 && request.PageSize.Value <= 30 ? request.PageSize.Value : 30;
            
            _specification.ApplyPaging((pageNumber - 1) * pageSize, pageSize);


            IEnumerable<FinancialSpending> spending = await _spendRepository.ListAsync(_specification);
            if (spending is null)
            {
                return Result.NotFound("Not Found");
            }
            return Result.Success(_mapper.Map<IEnumerable<FinancialSpendingDTO>>(spending));


        }
    }
}

