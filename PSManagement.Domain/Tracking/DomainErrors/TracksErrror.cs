using PSManagement.SharedKernel.DomainErrors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Domain.Tracking.DomainErrors
{
    public class TracksErrror
    {
        public static DomainError InvalidEntryError { get; } = new("TrackError.InvalidEntry.", "Invalid Project Data");

    }
}
