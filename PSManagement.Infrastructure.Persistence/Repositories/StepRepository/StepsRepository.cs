using PSManagement.Domain.Projects.Entities;
using PSManagement.Domain.Projects.Repositories;
using PSManagement.Infrastructure.Persistence.Repositories.Base;

namespace PSManagement.Infrastructure.Persistence.Repositories.StepRepository
{
    public class StepsRepository : BaseRepository<Step>, IStepsRepository
    {
        public StepsRepository(AppDbContext context) : base(context)
        {
        }

    }
}
