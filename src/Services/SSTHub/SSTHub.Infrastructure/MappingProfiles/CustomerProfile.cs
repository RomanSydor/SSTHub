using AutoMapper;
using SSTHub.Domain.Entities;
using SSTHub.Domain.ViewModels.Customer;
using SSTHub.Infrastructure.MappingProfiles.CustomConverters;
using System.Collections.Immutable;

namespace SSTHub.Infrastructure.MappingProfiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<ImmutableList<Customer>, ImmutableList<CustomerListItemViewModel>>()
                .ConvertUsing(new ImmutableListConverter<Customer, CustomerListItemViewModel>());

            CreateMap<Customer, CustomerListItemViewModel>();

            CreateMap<CustomerCreateViewModel, Customer>();
        }
    }
}