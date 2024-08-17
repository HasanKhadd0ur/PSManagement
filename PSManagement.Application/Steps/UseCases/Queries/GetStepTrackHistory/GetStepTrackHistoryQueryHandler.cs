using Ardalis.Result;
using AutoMapper;
using PSManagement.Application.Tracks.Common;
using PSManagement.Domain.Projects;
using PSManagement.Domain.Projects.Entities;
using PSManagement.Domain.Projects.Repositories;
using PSManagement.SharedKernel.CQRS.Query;
using PSManagement.SharedKernel.Specification;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
namespace PSManagement.Application.Steps.UseCases.Queries.GetStepTrackHistory
{
    public class GetStepTrackHistoryQueryHandler : IQueryHandler<GetStepTrackHistoryQuery, Result<IEnumerable<StepTrackDTO>>>
    {
        private readonly IStepsRepository _stepsRepository;
        private readonly BaseSpecification<Step> _specification;
        private readonly IMapper _mapper;

        public GetStepTrackHistoryQueryHandler(
            IStepsRepository stepsRepository,
            IMapper mapper)
        {
            _stepsRepository = stepsRepository;
            _specification = new StepSpecification();
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<StepTrackDTO>>> Handle(GetStepTrackHistoryQuery request, CancellationToken cancellationToken)
        {
            int pageNumber = request.PageNumber.HasValue && request.PageNumber.Value > 0 ? request.PageNumber.Value : 1;
            int pageSize = request.PageSize.HasValue && request.PageSize.Value > 0 && request.PageSize.Value <= 30 ? request.PageSize.Value : 30;
            _specification.AddInclude(e => e.StepTracks);
            _specification.AddInclude("StepTracks.Track");
            

            var steps = await _stepsRepository.GetByIdAsync(request.StepId,_specification);

            return Result.Success(_mapper.Map<IEnumerable<StepTrackDTO>>(steps.StepTracks.AsEnumerable().Skip((pageNumber - 1) * pageSize).Take(pageSize)));
        }
    }
}
