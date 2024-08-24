using AutoMapper;
using PSManagement.Application.Contracts.Authentication;
using PSManagement.Application.Customers.Common;
using PSManagement.Application.Customers.UseCases.Commands.AddContactInfo;
using PSManagement.Application.Customers.UseCases.Commands.CreateCustomer;
using PSManagement.Application.Customers.UseCases.Commands.UpdateCustomer;
using PSManagement.Application.Employees.Common;
using PSManagement.Application.Projects.Common;
using PSManagement.Application.Projects.UseCases.Commands.AddParticipant;
using PSManagement.Application.Projects.UseCases.Commands.AddProjectStep;
using PSManagement.Application.Projects.UseCases.Commands.ApproveProject;
using PSManagement.Application.Projects.UseCases.Commands.ChangeProjectTeamLeader;
using PSManagement.Application.Projects.UseCases.Commands.CreateProject;
using PSManagement.Application.Projects.UseCases.Commands.RemoveParticipant;
using PSManagement.Application.Projects.UseCases.Queries.ListAllProject;
using PSManagement.Application.Tracks.Common;
using PSManagement.Contracts.Authentication;
using PSManagement.Contracts.Customers.Requests;
using PSManagement.Contracts.Customers.Responses;
using PSManagement.Contracts.Projects.Requests;
using PSManagement.Contracts.Projects.Response;
using PSManagement.Contracts.Tracks.Response;
using PSManagement.SharedKernel.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSManagement.Api.Mappers
{
    public class CustomerMapperConfiguration : Profile
    {
        public CustomerMapperConfiguration()
        {
            CreateMap<CreateCustomerRequest, CreateCustomerCommand>().ReverseMap();
            CreateMap<UpdateCustomerCommand, UpdateCustomerRequest>().ReverseMap();

            CreateMap<AddContactInfoRequest, AddContactInfoCommand>().ReverseMap();
            CreateMap<CustomerDTO, CustomerResponse>();
            CreateMap<ContactInfoDTO, ContactInfoResponse>();

            CreateMap<CustomerResponse, CustomerDTO>().ReverseMap();
            
            CreateMap<IEnumerable<CustomerResponse>, ListCustomersResponse>()
                    .ConstructUsing(src => new ListCustomersResponse(src));

            CreateMap<AuthenticationResult,AuthenticationResponse>().ReverseMap();
        }
    }
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
            
            
            CreateMap<EmployeeResponse, EmployeeDTO>().ReverseMap();
            CreateMap<EmployeeParticipateResponse, EmployeeParticipateDTO>().ReverseMap();

            CreateMap<TrackDTO, TrackResponse>().ReverseMap();

        }
    }
}
