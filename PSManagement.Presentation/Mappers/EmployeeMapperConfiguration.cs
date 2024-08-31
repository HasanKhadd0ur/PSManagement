using AutoMapper;
using PSManagement.Application.Employees.Common;
using PSManagement.Application.Projects.Common;
using PSManagement.Contracts.Projects.Response;

namespace PSManagement.Presentation.Mappers
{
    public class EmployeeMapperConfiguration : Profile
    {
        public EmployeeMapperConfiguration()
        {

            CreateMap<EmployeeResponse, EmployeeDTO>().ReverseMap();
            CreateMap<EmployeeParticipateResponse, EmployeeParticipateDTO>().ReverseMap();

        }
    }
}
