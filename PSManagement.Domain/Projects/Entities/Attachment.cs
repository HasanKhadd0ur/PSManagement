using PSManagement.SharedKernel.Entities;

namespace PSManagement.Domain.Projects.Entities
{
    public class Attachment : BaseEntity
    {
        public int ProjectId { get; set; }
        public string AttachmentUrl { get; set; }
        public string AttachmentName { get; set; }
        public string AttachmentDescription { get; set; }

        #region Constructors
        public Attachment(string attachmentUrl, string attachmentName, string attachmentDescription, int projectId)
        {
            AttachmentUrl = attachmentUrl;
            AttachmentName = attachmentName;
            AttachmentDescription = attachmentDescription;
            ProjectId = projectId;
        }
        #endregion  Constructors

    }
}
