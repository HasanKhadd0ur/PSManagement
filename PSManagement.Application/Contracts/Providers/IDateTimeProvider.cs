using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Application.Contracts.Providers
{
    public interface IDateTimeProvider
    {
        public DateTime UtcNow { get; }
    }
}
