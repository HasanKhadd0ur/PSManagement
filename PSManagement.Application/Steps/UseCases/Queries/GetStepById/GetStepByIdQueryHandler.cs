using Ardalis.Result;
using AutoMapper;
using PSManagement.Application.Projects.Common;
using PSManagement.Domain.Projects.DomainErrors;
using PSManagement.Domain.Projects.Entities;
using PSManagement.Domain.Projects.Repositories;
using PSManagement.SharedKernel.CQRS.Query;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Steps.UseCases.Queries.GetStepById
{
    public class GetStepByIdQueryHandler : IQueryHandler<GetStepByIdQuery, Result<StepDTO>>
    {
        private readonly IStepsRepository _stepsRepository;
        private readonly IMapper _mapper;


        public GetStepByIdQueryHandler(
            IStepsRepository stepsRepository, 
            IMapper mapper)
        {
            _stepsRepository = stepsRepository;
            _mapper = mapper;
        }

        public async Task<Result<StepDTO>> Handle(GetStepByIdQuery request, CancellationToken cancellationToken)
        {
            Step step = await _stepsRepository.GetByIdAsync(request.StepId);
            if (step is null)
            {
                return Result.Invalid(StepsErrors.InvalidEntryError);
            }
            else
            {



                return Result.Success(_mapper.Map<StepDTO>(step));



            }
        }
    }

}
