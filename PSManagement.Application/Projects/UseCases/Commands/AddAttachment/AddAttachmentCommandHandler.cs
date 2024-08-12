using Ardalis.Result;
using PSManagement.Application.Contracts.Storage;
using PSManagement.Domain.Projects.Builders;
using PSManagement.Domain.Projects.Entities;
using PSManagement.Domain.Projects.Repositories;
using PSManagement.SharedKernel.CQRS.Command;
using PSManagement.SharedKernel.Interfaces;
using PSManagement.SharedKernel.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Projects.UseCases.Commands.AddAttachment
{
    public class AddAttachmentCommandHandler : ICommandHandler<AddAttachmentCommand, Result<int>> {
        private readonly IFileService _fileService;
        private readonly IRepository<Attachment> _attachmentRepository;
        private readonly IUnitOfWork _unitOfWork;
        
        public AddAttachmentCommandHandler(
            IFileService fileService,
            IRepository<Attachment> repository,
            IUnitOfWork unitOfWork)
        {
            _fileService = fileService;
            _attachmentRepository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(AddAttachmentCommand request, CancellationToken cancellationToken)
        {
            Result<string> pathResult = await _fileService.StoreFile(request.AttachmentName+Guid.NewGuid(),request.File);
            if (pathResult.IsSuccess)
            {
                Attachment attachment = new(pathResult.Value, request.AttachmentName, request.AttachmentDescription, request.ProjectId);

                attachment = await _attachmentRepository.AddAsync(attachment);
                await _unitOfWork.SaveChangesAsync();
                return Result.Success(attachment.Id);
            }
            else {
                return Result.Invalid(pathResult.ValidationErrors);
            }
        }
    }
}
