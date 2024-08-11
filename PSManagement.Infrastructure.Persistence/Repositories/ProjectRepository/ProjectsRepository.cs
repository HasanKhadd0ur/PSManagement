using PSManagement.Domain.Projects.Entities;
using PSManagement.Domain.Projects.Repositories;
using PSManagement.Infrastructure.Persistence.Repositories.Base;
using PSManagement.SharedKernel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Infrastructure.Persistence.Repositories.ProjectRepository
{
    public class ProjectsRepository : BaseRepository<Project> , IProjectsRepository
    {
        public ProjectsRepository(AppDbContext context) : base(context)
        {
        }
    }
}
