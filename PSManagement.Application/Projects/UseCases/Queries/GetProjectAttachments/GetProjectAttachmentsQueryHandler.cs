using Ardalis.Result;
using AutoMapper;
using PSManagement.Application.Projects.Common;
using PSManagement.Domain.Projects.Entities;
using PSManagement.SharedKernel.CQRS.Query;
using PSManagement.SharedKernel.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Projects.UseCases.Queries.GetProjectAttachments
{
    public class GetProjectAttachmentsQueryHandler : IQueryHandler<GetProjectAttachmentsQuery, Result<IEnumerable<AttachmentDTO>>>
    {
        private readonly IRepository<Attachment> _attachmentRepository;

        private readonly IMapper _mapper;

        public GetProjectAttachmentsQueryHandler(
            IMapper mapper,
            IRepository<Attachment> attachmentRepository)
        {
            _mapper = mapper;
            _attachmentRepository = attachmentRepository;
        }

        public async Task<Result<IEnumerable<AttachmentDTO>>> Handle(GetProjectAttachmentsQuery request, CancellationToken cancellationToken)
        {
            int pageNumber = request.PageNumber.HasValue && request.PageNumber.Value > 0 ? request.PageNumber.Value : 1;
            int pageSize = request.PageSize.HasValue && request.PageSize.Value > 0 && request.PageSize.Value <= 30 ? request.PageSize.Value : 30;


            var attachments = await _attachmentRepository.ListAsync();
            if (request.PageSize.HasValue && request.PageNumber.HasValue)
            {
                attachments = attachments.Where(e => e.ProjectId == request.ProjectId).Skip((pageNumber - 1) * pageSize).Take(pageSize);

            }
            else {
                attachments = attachments.Where(e => e.ProjectId == request.ProjectId);

            }

            return Result.Success(_mapper.Map<IEnumerable<AttachmentDTO>>(attachments));
        }
    }
}
