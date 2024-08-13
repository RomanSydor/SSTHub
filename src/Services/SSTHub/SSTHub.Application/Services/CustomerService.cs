using AutoMapper;
using SSTHub.Domain.Entities;
using SSTHub.Domain.Interfaces;
using SSTHub.Domain.Interfaces.UnitOfWork;
using SSTHub.Domain.ViewModels.Customer;
using System.Collections.Immutable;

namespace SSTHub.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IDateTimeService _dateTimeService;

        public CustomerService(IUnitOfWork unitOfWork,
            IMapper mapper,
            IDateTimeService dateTimeService) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _dateTimeService = dateTimeService;
        }

        public async Task<int> CreateAsync(CustomerCreateViewModel createViewModel)
        {
            var customer = _mapper.Map<Customer>(createViewModel);
            customer.CreatedAt = _dateTimeService.GetDateTimeNow(); 

            await _unitOfWork.CustomerRepository.CreateAsync(customer);
            await _unitOfWork.SaveChangesAsync();

            return customer.Id;
        }

        public async Task<ImmutableList<CustomerListItemViewModel>> GetByHubIdAsync(int hubId)
        {
            var customers = await _unitOfWork.CustomerRepository.GetByHubIdAsync(hubId);
            return _mapper.Map<ImmutableList<CustomerListItemViewModel>>(customers);
        }

        public async Task<ImmutableList<CustomerListItemViewModel>> GetByOrganizationIdAsync(int organizationId)
        {
            var customers = await _unitOfWork.CustomerRepository.GetByOrganizationIdAsync(organizationId);
            return _mapper.Map<ImmutableList<CustomerListItemViewModel>>(customers);
        }
    }
}
