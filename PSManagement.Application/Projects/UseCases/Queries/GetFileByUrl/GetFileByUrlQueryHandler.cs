using Ardalis.Result;
using AutoMapper;
using PSManagement.Application.Contracts.Storage;
using PSManagement.Application.Projects.Common;
using PSManagement.Domain.Projects.Entities;
using PSManagement.SharedKernel.CQRS.Query;
using PSManagement.SharedKernel.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Projects.UseCases.Queries.GetFileByUrl
{
    public class GetFileByUrlQueryHandler : IQueryHandler<GetFileByUrlQuery, Result<FileAttachmentDTO>>
    {
        private readonly IRepository<Attachment> _attachmentRepository;
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;

        public GetFileByUrlQueryHandler(
            IMapper mapper,
            IRepository<Attachment> attachmentRepository,
            IFileService fileService)
        {
            _mapper = mapper;
            _attachmentRepository = attachmentRepository;
            _fileService = fileService;
        }

        public async Task<Result<FileAttachmentDTO>> Handle(GetFileByUrlQuery request, CancellationToken cancellationToken)
        {


            var attachment = await _attachmentRepository.GetByIdAsync(request.AttachmentId);
            if (attachment is null)
            {

                return Result.NotFound("Not found ");

            }
            var result = await _fileService.RetreiveFile(attachment.AttachmentUrl);
            if (!result.IsSuccess)
            {

                return Result.NotFound("Not Found");

            }
            return Result.Success(new FileAttachmentDTO(attachment.AttachmentName, attachment.AttachmentDescription, result.Value));
        }
    }

}
