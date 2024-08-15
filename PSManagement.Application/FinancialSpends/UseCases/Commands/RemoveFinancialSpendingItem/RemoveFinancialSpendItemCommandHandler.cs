using Ardalis.Result;
using AutoMapper;
using PSManagement.Domain.FinancialSpends.Entities;
using PSManagement.Domain.FinincialSpending.Repositories;
using PSManagement.Domain.Projects.DomainErrors;
using PSManagement.Domain.Projects.Entities;
using PSManagement.Domain.Projects.Repositories;
using PSManagement.SharedKernel.CQRS.Command;
using PSManagement.SharedKernel.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.FinancialSpends.UseCases.Commands.RemoveFinancialSpendingItem
{
    public class RemoveFinancialSpendItemCommandHandler : ICommandHandler<RemoveFinancialSpendItemCommand, Result>
    {
        private readonly IProjectsRepository _projectsRepository;
        private readonly IFinancialSpendingRepository _spendRepository;
        private readonly IUnitOfWork _unitOfWork;
        



        public RemoveFinancialSpendItemCommandHandler(
            IFinancialSpendingRepository spendRepository,
            IProjectsRepository projectsRepository,
            IUnitOfWork unitOfWork)
        {
            _spendRepository = spendRepository;
            _projectsRepository = projectsRepository;
            _unitOfWork = unitOfWork;
        
        }



        public async Task<Result> Handle(RemoveFinancialSpendItemCommand request, CancellationToken cancellationToken)
        {
            Project project = await _projectsRepository.GetByIdAsync(request.ProjectId);
            if (project is null)
            {
                return Result.Invalid(ProjectsErrors.InvalidEntryError);
            }
            else
            {
                FinancialSpending spending = await _spendRepository.GetByIdAsync(request.Id);
                if (spending is null) {
                    return Result.NotFound();
                }
                await _spendRepository.DeleteAsync(spending);

                await _unitOfWork.SaveChangesAsync();
                return Result.Success();



            }
        }
    }
}
