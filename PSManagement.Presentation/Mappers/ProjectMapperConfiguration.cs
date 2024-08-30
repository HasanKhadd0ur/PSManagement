using AutoMapper;
using PSManagement.Application.Projects.Common;
using PSManagement.Application.Projects.UseCases.Commands.AddParticipant;
using PSManagement.Application.Projects.UseCases.Commands.AddProjectStep;
using PSManagement.Application.Projects.UseCases.Commands.ApproveProject;
using PSManagement.Application.Projects.UseCases.Commands.ChangeProjectTeamLeader;
using PSManagement.Application.Projects.UseCases.Commands.CreateProject;
using PSManagement.Application.Projects.UseCases.Commands.RemoveParticipant;
using PSManagement.Application.Projects.UseCases.Queries.ListAllProject;
using PSManagement.Application.Tracks.Common;
using PSManagement.Contracts.Projects.Requests;
using PSManagement.Contracts.Projects.Response;
using PSManagement.Contracts.Tracks.Response;

namespace PSManagement.Api.Mappers
{
    public class ProjectMapperConfiguration : Profile
    {
        public ProjectMapperConfiguration()
        {
            CreateMap<CreateProjectRequest, CreateProjectCommand>().ReverseMap();
            CreateMap<ListAllProjectsRequest, ListAllProjectsQuery>().ReverseMap();
            CreateMap<ApproveProjectRequest, ApproveProjectCommand>().ReverseMap();
            CreateMap<AddParticipantRequest, AddParticipantCommand>().ReverseMap();
            CreateMap<AddProjectStepRequest, AddProjectStepCommand>().ReverseMap();
            CreateMap<ChangeProjectTeamLeaderRequest, ChangeProjectTeamLeaderCommand>().ReverseMap();
            CreateMap<RemoveParticipantRequest, RemoveParticipantCommand>().ReverseMap();
            CreateMap<ProjectDTO,ProjectResponse>().ReverseMap();
            CreateMap<GetProjectsByProjectManagerRequest,GetProjectsByFilterQuery>().ConstructUsing(
                s => new GetProjectsByFilterQuery(null,null,null,null,s.ProjectManagerId,null,null,null)
            );
            
            
            CreateMap<TrackDTO, TrackResponse>().ReverseMap();

        }
    }
}
