using AutoMapper;
using PSManagement.Application.Customers.Common;
using PSManagement.Application.Employees.Common;
using PSManagement.Application.FinancialSpends.Common;
using PSManagement.Application.FinancialSpends.UseCases.Commands.CreateFinancialSpendItem;
using PSManagement.Application.Projects.Common;
using PSManagement.Application.Tracks.Common;
using PSManagement.Domain.Customers.Entities;
using PSManagement.Domain.Customers.ValueObjects;
using PSManagement.Domain.Employees.Entities;
using PSManagement.Domain.FinancialSpends.Entities;
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

            CreateMap<StepDTO, Step>().ReverseMap();

            CreateMap<Employee, EmployeeDTO>()
                .ForMember(e => e.DepartmentName, op => op.MapFrom(e => e.Department.Name));


            CreateMap< EmployeeParticipate, EmployeeParticipateDTO>()
                .ForMember(d => d.ProjectInfo, opt => opt.MapFrom(s => s.Project.ProjectInfo))
                .ForMember(d => d.Employee, op => op.MapFrom(e => e.Employee))
                
                ;

            CreateMap<Project, ProjectInfo>()
                .ConvertUsing(project => project.ProjectInfo);

            CreateMap<TrackDTO, Track>().ReverseMap();
            CreateMap<StepTrack, StepTrackDTO>()
                .ForMember(d => d.TrackDate, op=> op.MapFrom( src => src.Track.TrackDate));

            CreateMap<FinancialSpendingDTO, FinancialSpending>().ReverseMap();
           
            
            CreateMap<Project, ProjectDTO>().ReverseMap();


            CreateMap <CreateFinancialSpendItemCommand,FinancialSpending> ()
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



        }
    }

}
