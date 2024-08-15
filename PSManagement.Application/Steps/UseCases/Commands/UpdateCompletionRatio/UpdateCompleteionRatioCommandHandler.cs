using Ardalis.Result;
using PSManagement.Domain.Projects.DomainErrors;
using PSManagement.Domain.Projects.Entities;
using PSManagement.Domain.Projects.Repositories;
using PSManagement.SharedKernel.CQRS.Command;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Steps.UseCases.Commands.UpdateCompletionRatio
{
    public class UpdateCompleteionRatioCommandHandler : ICommandHandler<UpdateCompletionRatioCommand, Result>
    {
        private readonly IStepsRepository _stepsRepository;


        public UpdateCompleteionRatioCommandHandler(IStepsRepository stepsRepository)
        {
            _stepsRepository = stepsRepository;
        }

        public async Task<Result> Handle(UpdateCompletionRatioCommand request, CancellationToken cancellationToken)
        {
            Step step = await _stepsRepository.GetByIdAsync(request.StepId);
            if (step is null)
            {
                return Result.Invalid(StepsErrors.InvalidEntryError);
            }
            else
            {
                if (request.CompletionRatio < step.CurrentCompletionRatio)
                {
                    return Result.Invalid(StepsErrors.InvalidCompletionRatioError);
                }

                step.CurrentCompletionRatio = request.CompletionRatio;
                await _stepsRepository.UpdateAsync(step);


                return Result.Success();



            }
        }
    }

}
