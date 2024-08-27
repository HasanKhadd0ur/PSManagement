using Ardalis.Result;
using PSManagement.Domain.Projects.DomainErrors;
using PSManagement.Domain.Projects.Entities;
using PSManagement.Domain.Projects.Repositories;
using PSManagement.SharedKernel.CQRS.Command;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Steps.UseCases.Commands.UpdateStepInformaion
{
    public class UpdateStepInformationCommandHandler : ICommandHandler<UpdateStepInformationCommand, Result>
    {
        private readonly IStepsRepository _stepsRepository;


        public UpdateStepInformationCommandHandler(IStepsRepository stepsRepository)
        {
            _stepsRepository = stepsRepository;
        }

        public async Task<Result> Handle(UpdateStepInformationCommand request, CancellationToken cancellationToken)
        {
            Step step = await _stepsRepository.GetByIdAsync(request.StepId);
            if (step is null)
            {
                return Result.Invalid(StepsErrors.InvalidEntryError);
            }
            else
            {


                step.ChangeInfo(request.StepInfo);
                await _stepsRepository.UpdateAsync(step);


                return Result.Success();



            }
        }
    }

}
