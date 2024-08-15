using Ardalis.Result;
using PSManagement.Domain.Projects.DomainErrors;
using PSManagement.Domain.Projects.Entities;
using PSManagement.Domain.Projects.Repositories;
using PSManagement.SharedKernel.CQRS.Command;
using PSManagement.SharedKernel.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Steps.UseCases.Commands.RemoveStep
{
    public class RemoveStepCommandHandler : ICommandHandler<RemoveStepCommand, Result>
    {
        private readonly IStepsRepository _stepsRepository;

        private readonly IUnitOfWork _unitOfWork;


        public RemoveStepCommandHandler(IStepsRepository stepsRepository, IUnitOfWork unitOfWork)
        {
            _stepsRepository = stepsRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(
            RemoveStepCommand request, 
            CancellationToken cancellationToken
            )
        {
            Step step = await _stepsRepository.GetByIdAsync(request.StepId);
            if (step is null)
            {
                return Result.Invalid(StepsErrors.InvalidEntryError);
            }
            else
            {

                await _stepsRepository.DeleteAsync(step);

                await _unitOfWork.SaveChangesAsync();
                return Result.Success();



            }
        }
    }

}
