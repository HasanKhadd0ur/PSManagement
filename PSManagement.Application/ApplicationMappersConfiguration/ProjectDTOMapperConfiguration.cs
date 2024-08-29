using AutoMapper;
using PSManagement.Application.Projects.Common;
using PSManagement.Application.Projects.UseCases.Commands.CompleteProgressProject;
using PSManagement.Application.ProjectsTypes.UseCases.Commands.CreateNewType;
using PSManagement.Application.ProjectsTypes.Common;
using PSManagement.Domain.Projects.Entities;
using PSManagement.Domain.Projects.ValueObjects;
using PSManagement.Domain.ProjectsTypes.Entites;

namespace PSManagement.Application.Mappers
{
    public class ProjectDTOMapperConfiguration : Profile {

        public ProjectDTOMapperConfiguration()
        {

            CreateMap<Project, ProjectDTO>().ReverseMap();
            CreateMap<Project, ProjectDetailsDTO>().ReverseMap();
           CreateMap<ProjectType, ProjectTypeDTO>().ReverseMap();

            CreateMap<Project, ProjectInfo>()
                .ConvertUsing(project => project.ProjectInfo);


            CreateMap<EmployeeParticipate, EmployeeParticipateDTO>()
                .ForMember(d => d.ProjectInfo, opt => opt.MapFrom(s => s.Project.ProjectInfo))
                .ForMember(d => d.Employee, op => op.MapFrom(e => e.Employee))

                ;

            CreateMap<CreateNewTypeCommand, ProjectType>();
            CreateMap<UpdateTypeCommand, ProjectType>();

            CreateMap<ParticipationChange, ParticipationChangeDTO>().ReverseMap();

            CreateMap <CompleteProjectCommand, ProjectCompletion>();

        }
    }

}
