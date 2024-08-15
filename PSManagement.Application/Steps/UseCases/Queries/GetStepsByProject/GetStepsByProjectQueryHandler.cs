using Ardalis.Result;
using AutoMapper;
using PSManagement.Application.Projects.Common;
using PSManagement.Domain.Projects;
using PSManagement.Domain.Projects.Entities;
using PSManagement.Domain.Projects.Repositories;
using PSManagement.SharedKernel.CQRS.Query;
using PSManagement.SharedKernel.Specification;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Steps.UseCases.Queries.GetStepsByProject
{
    public class GetStepsByProjectQueryHandler : IQueryHandler<GetStepsByProjectQuery, Result<IEnumerable<StepDTO>>>
    {
        private readonly IStepsRepository _stepsRepository;
        private readonly BaseSpecification<Step> _specification;
        private readonly IMapper _mapper;

        public GetStepsByProjectQueryHandler(
            IMapper mapper,
            IStepsRepository projectsRepository)
        {
            _mapper = mapper;
            _stepsRepository = projectsRepository;
            _specification = new StepSpecification();
        }

        public async Task<Result<IEnumerable<StepDTO>>> Handle(GetStepsByProjectQuery request, CancellationToken cancellationToken)
        {
            int pageNumber = request.PageNumber.HasValue && request.PageNumber.Value > 0 ? request.PageNumber.Value : 1;
            int pageSize = request.PageSize.HasValue && request.PageSize.Value > 0 && request.PageSize.Value <= 30 ? request.PageSize.Value : 30;


            _specification.ApplyPaging((pageNumber - 1) * pageSize, pageSize);

            var steps = await _stepsRepository.ListAsync(_specification);

            return Result.Success(_mapper.Map<IEnumerable<StepDTO>>(steps));
        }
    }
}
