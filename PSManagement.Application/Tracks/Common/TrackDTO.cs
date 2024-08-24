using PSManagement.Application.Employees.Common;
using PSManagement.Domain.Tracking.ValueObjects;
using PSManagement.Domain.Projects.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Application.Tracks.Common
{
    public class TrackDTO
    {
        public int Id { get; set; }
        public TrackInfo TrackInfo { get; set; }
        public String Notes { get; set; }
        public int ProjectId { get; set; }
        public ProjectInfo ProjectInfo {get; set;}
    }
}
