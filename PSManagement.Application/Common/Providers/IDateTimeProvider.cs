using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Application.Common.Services
{
    public interface IDateTimeProvider
    {
        public DateTime UtcNow { get; }
    }
}
