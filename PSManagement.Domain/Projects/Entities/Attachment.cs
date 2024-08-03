using PSManagement.SharedKernel.Entities;

namespace PSManagement.Domain.Projects.Entities
{
    public class Attachment : BaseEntity
    {

        public string AttachmentUrl { get; set; }
        public string AttachmentName { get; set; }
        public string AttachmenDescription { get; set; }

    }
}
