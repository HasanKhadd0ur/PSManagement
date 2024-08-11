using PSManagement.Application.Contracts.Providers;
using System;
using System.Text;

namespace PSManagement.Infrastructure.Services.Providers
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
