using PSManagement.Domain.FinancialSpends.Entities;
using PSManagement.Domain.FinincialSpending.Repositories;
using PSManagement.Infrastructure.Persistence.Repositories.Base;

namespace PSManagement.Infrastructure.Persistence.Repositories.ProjectRepository
{
    public class FinancialSpendingRepository : BaseRepository<FinancialSpending>, IFinancialSpendingRepository
    {
        public FinancialSpendingRepository(AppDbContext context) : base(context)
        {
        }
    }

}
