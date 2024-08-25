using System;

namespace PSManagement.Contracts.Projects.Response
{
    public class ProjectCompletionResponse
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public ProjectResponse Project { get; set; }
        public DateTime CompletionDate { get; set; }
        public String CustomerNotes { get; set; }
        public int CustomerRate { get; set; }
    }
    }
