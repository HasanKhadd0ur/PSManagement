﻿using Ardalis.Result;
using PSManagement.Domain.Projects.DomainErrors;
using PSManagement.Domain.Projects.Entities;
using PSManagement.Domain.Projects.Repositories;
using PSManagement.SharedKernel.CQRS.Command;
using PSManagement.SharedKernel.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Projects.UseCases.Commands.ApproveProject
{
    public class ApproveProjectCommandHandler : ICommandHandler<ApproveProjectCommand, Result>
    {
        private readonly IProjectsRepository _projectsRepository;
        private readonly IUnitOfWork _unitOfWork;
        
        public ApproveProjectCommandHandler(
            IProjectsRepository projectsRepository,
            IUnitOfWork unitOfWork
            )
        {

            _projectsRepository = projectsRepository;
            _unitOfWork = unitOfWork;
            
        }

        public async Task<Result> Handle(ApproveProjectCommand request, CancellationToken cancellationToken)
        {
            Project project = await _projectsRepository.GetByIdAsync(request.ProjectId);
            if (project is null)
            {
                return Result.Invalid(ProjectsErrors.InvalidEntryError);
            }
            else
            {

                project.Approve(request.ProjectAggreement);
                await _unitOfWork.SaveChangesAsync();

                return Result.Success();



            }
        }
    }

}