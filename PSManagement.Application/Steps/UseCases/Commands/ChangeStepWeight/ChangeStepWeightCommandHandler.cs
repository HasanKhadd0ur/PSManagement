using Ardalis.Result;
using PSManagement.Domain.Projects.DomainErrors;
using PSManagement.Domain.Projects.Entities;
using PSManagement.Domain.Projects.Repositories;
using PSManagement.SharedKernel.CQRS.Command;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Steps.UseCases.Commands.ChangeStepWeight
{
    public class ChangeStepWeightCommandHandler : ICommandHandler<ChangeStepWeightCommand, Result>
    {
        private readonly IStepsRepository _stepsRepository;
        

        public ChangeStepWeightCommandHandler(IStepsRepository stepsRepository)
        {
            _stepsRepository = stepsRepository;
        }

        public async Task<Result> Handle(ChangeStepWeightCommand request, CancellationToken cancellationToken)
        {
            Step step = await _stepsRepository.GetByIdAsync(request.StepId);
            if (step is null)
            {
                return Result.Invalid(StepsErrors.InvalidEntryError);
            }
            else
            {
                if (request.Weight < 0) {
                    return Result.Invalid(StepsErrors.InvalidWeightError);
                }

                step.UpdateWeight(request.Weight);
                await _stepsRepository.UpdateAsync(step);

                
                return Result.Success();



            }
        }
    }

}
