using AutoMapper;
using PSManagement.Application.Contracts.Authentication;
using PSManagement.Application.Customers.Common;
using PSManagement.Application.Employees.Common;
using PSManagement.Application.FinancialSpends.Common;
using PSManagement.Application.FinancialSpends.UseCases.Commands.CreateFinancialSpendItem;
using PSManagement.Application.Projects.Common;
using PSManagement.Application.Tracks.Common;
using PSManagement.Application.Tracks.UseCaes.Commands.AddEmployeeTrack;
using PSManagement.Application.Tracks.UseCaes.Commands.AddStepTrack;
using PSManagement.Application.Tracks.UseCaes.Commands.CreateTrack;
using PSManagement.Domain.Customers.Entities;
using PSManagement.Domain.Customers.ValueObjects;
using PSManagement.Domain.Employees.Entities;
using PSManagement.Domain.FinancialSpends.Entities;
using PSManagement.Domain.Identity.Entities;
using PSManagement.Domain.Projects.Entities;
using PSManagement.Domain.Projects.ValueObjects;
using PSManagement.Domain.Tracking;
using PSManagement.Domain.Tracking.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Application.Mappers
{
    class MapperConfiguration :Profile
    {
        public MapperConfiguration()
        {
            CreateMap<CustomerDTO, Customer>().ReverseMap();
            CreateMap<ContactInfoDTO, ContactInfo>().ReverseMap();

            CreateMap<Step, StepDTO>()
             ;

            CreateMap<Employee, EmployeeDTO>()
                .ForMember(e => e.DepartmentName, op => op.MapFrom(e => e.Department.Name));


            CreateMap< EmployeeParticipate, EmployeeParticipateDTO>()
                .ForMember(d => d.ProjectInfo, opt => opt.MapFrom(s => s.Project.ProjectInfo))
                .ForMember(d => d.Employee, op => op.MapFrom(e => e.Employee))
                
                ;
            CreateMap<StepTrack, StepTrackDTO>()
                .ForMember(d => d.StepInfo, opt => opt.MapFrom(s => s.Step.StepInfo))
                .ForMember(d => d.TrackInfo, op => op.MapFrom(e => e.Track.TrackInfo))
                ;
            CreateMap<EmployeeTrack, EmployeeTrackDTO>()
                .ForMember(d => d.TrackInfo, op => op.MapFrom(e => e.Track.TrackInfo))
                ;

            CreateMap<Project, ProjectInfo>()
                .ConvertUsing(project => project.ProjectInfo);

            CreateMap<Track, TrackDTO>();

            CreateMap<CreateTrackCommand, Track>().ReverseMap();
            CreateMap<AddEmployeeTrackCommand, EmployeeTrack>().ReverseMap();

            CreateMap<AddStepTrackCommand, StepTrack>()
                .ForMember(e => e.OldExecutionRatio, op => op.Ignore());

            CreateMap<FinancialSpendingDTO, FinancialSpending>().ReverseMap();
           
            
            CreateMap<Project, ProjectDTO>().ReverseMap();
            CreateMap<Project, ProjectDetailsDTO>().ReverseMap();


            CreateMap<CreateFinancialSpendItemCommand,FinancialSpending> ()
                .ForMember(d=>d.Id, op => op.Ignore())
                .ForMember(d=> d.Events, op => op.Ignore())
                .ConstructUsing(src => new FinancialSpending(
                    src.ProjectId,
                    src.LocalPurchase,
                    src.ExternalPurchase,
                    src.CostType,
                    src.Description,
                    src.ExpectedSpendingDate
                ))
                ;

            CreateMap<Role,RoleDTO>().ReverseMap();

        }
    }

}
