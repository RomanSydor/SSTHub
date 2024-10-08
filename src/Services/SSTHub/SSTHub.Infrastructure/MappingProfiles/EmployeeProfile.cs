﻿using AutoMapper;
using SSTHub.Domain.Entities;
using SSTHub.Domain.ViewModels.Employee;
using SSTHub.Infrastructure.MappingProfiles.CustomConverters;
using System.Collections.Immutable;

namespace SSTHub.Infrastructure.MappingProfiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile() 
        {
            CreateMap<ImmutableList<Employee>, ImmutableList<EmployeeListItemViewModel>>()
                .ConvertUsing(new ImmutableListConverter<Employee, EmployeeListItemViewModel>());
            CreateMap<ImmutableList<Employee>, ImmutableList<EmployeeDetailsViewModel>>()
                .ConvertUsing(new ImmutableListConverter<Employee, EmployeeDetailsViewModel>());

            CreateMap<Employee, EmployeeListItemViewModel>();
            CreateMap<Employee, EmployeeDetailsViewModel>();

            CreateMap<EmployeeCreateViewModel, Employee>();
        }
    }
}
