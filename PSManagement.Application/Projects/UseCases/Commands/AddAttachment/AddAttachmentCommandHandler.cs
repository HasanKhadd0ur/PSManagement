using Ardalis.Result;
using PSManagement.Application.Contracts.Storage;
using PSManagement.Domain.Projects;
using PSManagement.Domain.Projects.Builders;
using PSManagement.Domain.Projects.DomainErrors;
using PSManagement.Domain.Projects.Entities;
using PSManagement.Domain.Projects.Repositories;
using PSManagement.SharedKernel.CQRS.Command;
using PSManagement.SharedKernel.Interfaces;
using PSManagement.SharedKernel.Repositories;
using PSManagement.SharedKernel.Specification;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Projects.UseCases.Commands.AddAttachment
{
    public class AddAttachmentCommandHandler : ICommandHandler<AddAttachmentCommand, Result<int>> {
        private readonly IFileService _fileService;
        private readonly IRepository<Attachment> _attachmentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProjectsRepository _projectsRepository;
        private readonly BaseSpecification<Project> _specification;

        public AddAttachmentCommandHandler(
            IFileService fileService,
            IRepository<Attachment> repository,
            IUnitOfWork unitOfWork,
            IProjectsRepository projectsRepository)
        {
            _fileService = fileService;
            _attachmentRepository = repository;
            _unitOfWork = unitOfWork;
            _projectsRepository = projectsRepository;
            _specification = new ProjectSpecification();
        }

        public async Task<Result<int>> Handle(AddAttachmentCommand request, CancellationToken cancellationToken)
        {
            _unitOfWork.BeginTransaction();
            _specification.AddInclude(e => e.Attachments);

            // save the file on the uploaded files
            Result<string> pathResult = await _fileService.StoreFile(request.AttachmentName+Guid.NewGuid(),request.File);
          
            // check if the file uploaded 
            if (pathResult.IsSuccess)
            {

                // get the project 
                Project project = await _projectsRepository.GetByIdAsync(request.ProjectId, _specification);

                // checking if the project exist
                if (project is null)
                {
                    await _unitOfWork.Rollback();
                    return Result.Invalid(ProjectsErrors.InvalidEntryError);
                }

                Attachment attachment = new(pathResult.Value, request.AttachmentName, request.AttachmentDescription, request.ProjectId);

                project.AddAttachment(pathResult.Value, request.AttachmentName, request.AttachmentDescription, request.ProjectId);
                
                await _unitOfWork.SaveChangesAsync();
                return Result.Success(attachment.Id);
            }
            else {

                await _unitOfWork.Rollback();
                return Result.Invalid(pathResult.ValidationErrors);
            }
        }
    }
}
