using PSManagement.Domain.Projects.Entities;
using PSManagement.SharedKernel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Domain.Projects.Repositories
{
    public interface IStepsRepository : IRepository<Step>
    {
    }
}
