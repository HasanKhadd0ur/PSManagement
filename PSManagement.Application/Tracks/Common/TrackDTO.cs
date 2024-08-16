using PSManagement.Application.Employees.Common;
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
        public bool IsCompleted { get; set; }
        public DateTime TrackDate { get; set; }
        public String TrackNote { get; set; }
        public int ProjectId { get; set; }

    }
}
