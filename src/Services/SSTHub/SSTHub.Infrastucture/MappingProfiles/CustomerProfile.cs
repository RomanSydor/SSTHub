using AutoMapper;
using SSTHub.Domain.Entities;
using SSTHub.Domain.ViewModels.Customer;

namespace SSTHub.Infrastucture.MappingProfiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile() 
        {
            CreateMap<Customer, CustomerListItemViewModel>();

            CreateMap<CustomerCreateViewModel, Customer>();
        }
    }
}
