﻿using AutoMapper;
using SSTHub.Domain.Entities;
using SSTHub.Domain.Interfaces;
using SSTHub.Domain.Interfaces.UnitOfWork;
using SSTHub.Domain.ViewModels.Customer;

namespace SSTHub.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> CreateAsync(CustomerCreateViewModel createViewModel)
        {
            var customer = _mapper.Map<Customer>(createViewModel);
            customer.CreatedAt = DateTime.Now; 

            await _unitOfWork.CustomerRepository.CreateAsync(customer);
            await _unitOfWork.SaveChangesAsync();

            return customer.Id;
        }

        public async Task<IEnumerable<CustomerListItemViewModel>> GetByHubIdAsync(int hubId, int amount, int page)
        {
            var customers = await _unitOfWork.CustomerRepository.GetByHubIdAsync(hubId, amount, page);
            return _mapper.Map<IEnumerable<CustomerListItemViewModel>>(customers);
        }

        public async Task<IEnumerable<CustomerListItemViewModel>> GetByOrganizationIdAsync(int organizationId, int amount, int page)
        {
            var customers = await _unitOfWork.CustomerRepository.GetByOrganizationIdAsync(organizationId, amount, page);
            return _mapper.Map<IEnumerable<CustomerListItemViewModel>>(customers);
        }
    }
}
