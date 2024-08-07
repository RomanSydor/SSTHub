using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using SSTHub.Domain.Interfaces;
using SSTHub.Domain.ViewModels.Customer;
using System.Collections.Immutable;

namespace SSTHub.API.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [EnableQuery]
        [HttpGet("ByOrganizationId/{organizationId}")]
        public async Task<ImmutableList<CustomerListItemViewModel>> GetOrganizationId([FromRoute] int organizationId)
        {
            return await _customerService.GetByOrganizationIdAsync(organizationId);
        }

        [EnableQuery]
        [HttpGet("ByHubId/{hubId}")]
        public async Task<ImmutableList<CustomerListItemViewModel>> GetByHubId([FromRoute] int hubId)
        {
            return await _customerService.GetByHubIdAsync(hubId);
        }

        [HttpPost]
        public async Task<int> Create([FromBody] CustomerCreateViewModel createViewModel)
        {
            return await _customerService.CreateAsync(createViewModel);
        }
    }
}
