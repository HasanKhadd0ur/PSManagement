using Ardalis.Result;
using AutoMapper;
using PSManagement.Application.Projects.Common;
using PSManagement.Domain.Projects.Entities;
using PSManagement.SharedKernel.CQRS.Query;
using PSManagement.SharedKernel.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Projects.UseCases.Queries.GetParticipationChangeHistory
{
    public class GetParticipationChangeHistoryQueryHandler : IQueryHandler<GetParticipationChangeHistoryQuery, Result<IEnumerable<ParticipationChangeDTO>>>
    {
        private readonly IRepository<ParticipationChange> _repository;
        private readonly IMapper _mapper;

        public GetParticipationChangeHistoryQueryHandler(
            IMapper mapper,
            IRepository<ParticipationChange> repository)
        {

            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Result<IEnumerable<ParticipationChangeDTO>>> Handle(GetParticipationChangeHistoryQuery request, CancellationToken cancellationToken)
        {

            var result = await _repository.ListAsync();
            result = result.Where(e => e.ProjectId == request.ProjectId);
            
            return Result.Success(_mapper.Map<IEnumerable<ParticipationChangeDTO>>(result));
        }
    }

}
