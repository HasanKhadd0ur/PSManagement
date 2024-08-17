namespace PSManagement.Application.Projects.Common
{
    public class AttachmentDTO
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string AttachmentUrl { get; set; }
        public string AttachmentName { get; set; }
        public string AttachmentDescription { get; set; }
    }
}