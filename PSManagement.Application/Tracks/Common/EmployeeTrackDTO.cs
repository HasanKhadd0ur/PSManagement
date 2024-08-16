﻿using PSManagement.Domain.Tracking.ValueObjects;

namespace PSManagement.Application.Tracks.Common
{
    public class EmployeeTrackDTO
    {
        public int EmloyeeId { get; set; }
        public int TrackId { get; set; }
        public TrackInfo TrackInfo { get; set; }
        public EmployeeWorkInfo EmployeeWorkInfo { get; set; }
        public EmployeeWork EmployeeWork { get; set; }
        public string Notes { get; set; }
    }
}