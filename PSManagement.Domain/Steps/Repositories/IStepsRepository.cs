using PSManagement.Domain.Steps.Entities;
using PSManagement.SharedKernel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Domain.Steps.Repositories
{
    public interface IStepsRepository : IRepository<Step>
    {
    }
}
