using Ardalis.Result;
using PSManagement.Domain.Projects;
using PSManagement.Domain.Projects.DomainErrors;
using PSManagement.Domain.Projects.Entities;
using PSManagement.Domain.Projects.Repositories;
using PSManagement.SharedKernel.CQRS.Command;
using PSManagement.SharedKernel.Interfaces;
using PSManagement.SharedKernel.Repositories;
using PSManagement.SharedKernel.Specification;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Projects.UseCases.Commands.RemoveAttachment
{
    public class RemoveAttachmentCommandHandler : ICommandHandler<RemoveAttachmentCommand, Result>
    {
        private readonly IRepository<Attachment> _attachmentRepository;
        private readonly IProjectsRepository _projectsRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly BaseSpecification<Project> _specification;

        public RemoveAttachmentCommandHandler(
            IProjectsRepository projectsRepository,
            IUnitOfWork unitOfWork,
            IRepository<Attachment> attachmentRepository)
        {

            _specification = new ProjectSpecification();
            _projectsRepository = projectsRepository;
            _unitOfWork = unitOfWork;
            _attachmentRepository = attachmentRepository;
        }

        public async Task<Result> Handle(RemoveAttachmentCommand request, CancellationToken cancellationToken)
        {
            _specification.AddInclude(e => e.Attachments);

            Project project = await _projectsRepository.GetByIdAsync(request.ProjectId, _specification);
            if (project is null)
            {
                return Result.Invalid(ProjectsErrors.InvalidEntryError);
            }
            else
            {
                if (!project.HasAttachment(request.AttachmentId))
                {

                    return Result.Invalid(ProjectsErrors.AttachmentUnExist);
                }

                project.DropAttachment(request.AttachmentId);

                await _unitOfWork.SaveChangesAsync();

                return Result.Success();


            }
        }
    }

}
