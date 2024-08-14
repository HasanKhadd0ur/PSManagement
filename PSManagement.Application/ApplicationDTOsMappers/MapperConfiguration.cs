using AutoMapper;
using PSManagement.Application.Customers.Common;
using PSManagement.Application.Employees.Common;
using PSManagement.Application.FinancialSpends.Common;
using PSManagement.Application.Projects.Common;
using PSManagement.Application.Tracks.Common;
using PSManagement.Domain.Customers.Entities;
using PSManagement.Domain.Customers.ValueObjects;
using PSManagement.Domain.Employees.Entities;
using PSManagement.Domain.FinancialSpends.Entities;
using PSManagement.Domain.Projects.Entities;
using PSManagement.Domain.Tracking;
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
            CreateMap<EmployeeParticipateDTO, EmployeeParticipate>()
                .ForMember(d=>d.Project ,op =>op.Ignore())
                ;
            CreateMap< EmployeeParticipate, EmployeeParticipateDTO>()
                .ForMember(d => d.ProjectInfo, op => op.MapFrom(e => e.Project.ProjectInfo));
                
            CreateMap<EmployeeParticipate, EmployeeParticipateDTO>()
                .ForMember(d => d.ProjectInfo, op => op.MapFrom(e=>e.Project.ProjectInfo));


            CreateMap<TrackDTO, Track>().ReverseMap();
            CreateMap<FinancialSpendingDTO, FinancialSpending>().ReverseMap();
            CreateMap<Project, ProjectDTO>().ReverseMap();

        }
    }

}
