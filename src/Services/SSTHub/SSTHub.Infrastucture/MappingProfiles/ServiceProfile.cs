﻿using AutoMapper;
using SSTHub.Domain.Entities;
using SSTHub.Domain.ViewModels.Service;
using SSTHub.Infrastucture.MappingProfiles.CustomConverters;
using System.Collections.Immutable;

namespace SSTHub.Infrastucture.MappingProfiles
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<ImmutableList<Service>, ImmutableList<ServiceListItemViewModel>>()
              .ConvertUsing(new ImmutableListConverter<Service, ServiceListItemViewModel>());
            CreateMap<ImmutableList<Service>, ImmutableList<ServiceDetailsViewModel>>()
               .ConvertUsing(new ImmutableListConverter<Service, ServiceDetailsViewModel>());

            CreateMap<Service, ServiceListItemViewModel>();
            CreateMap<Service, ServiceDetailsViewModel>();

            CreateMap<ServiceCreateViewModel, Service>();
        }
    }
}
