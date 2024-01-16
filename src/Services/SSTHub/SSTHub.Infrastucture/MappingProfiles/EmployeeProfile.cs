using AutoMapper;
using SSTHub.Domain.Entities;
using SSTHub.Domain.ViewModels.Employee;

namespace SSTHub.Infrastucture.MappingProfiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile() 
        {
            CreateMap<Employee, EmployeeListItemViewModel>();
        }
    }
}
