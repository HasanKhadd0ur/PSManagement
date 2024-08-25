using System;

namespace PSManagement.Application.Projects.Common
{
    public class ProjectCompletionDTO 
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public ProjectDTO Project { get; set; }
        public DateTime CompletionDate { get; set; }
        public String CustomerNotes { get; set; }
        public int CustomerRate { get; set; }

    }
}