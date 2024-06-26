﻿using AutoMapper;
using SSTHub.Domain.Entities;
using SSTHub.Domain.ViewModels.Service;

namespace SSTHub.Infrastucture.MappingProfiles
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<ServiceCreateViewModel, Service>();
        }
    }
}
