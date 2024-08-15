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

namespace PSManagement.Application.FinancialSpends.UseCases.Commands.UpateFinancialSpendingItem
{
    public class UpdateFinancialSpendItemCommandHandler : ICommandHandler<UpdateFinancialSpendItemCommand, Result>
    {
        private readonly IProjectsRepository _projectsRepository;
        private readonly IFinancialSpendingRepository _spendRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;




        public UpdateFinancialSpendItemCommandHandler(
            IFinancialSpendingRepository spendRepository,
            IProjectsRepository projectsRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _spendRepository = spendRepository;
            _projectsRepository = projectsRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }



        public async Task<Result> Handle(UpdateFinancialSpendItemCommand request, CancellationToken cancellationToken)
        {
            Project project = await _projectsRepository.GetByIdAsync(request.ProjectId);
            if (project is null)
            {
                return Result.Invalid(ProjectsErrors.InvalidEntryError);
            }
            else
            {
                FinancialSpending spending = await _spendRepository.GetByIdAsync(request.Id);
                if (spending is null)
                {
                    return Result.NotFound();
                }
                await _spendRepository.UpdateAsync(_mapper.Map<FinancialSpending>(request));
                await _unitOfWork.SaveChangesAsync();
                return Result.Success();



            }
        }
    }
}

