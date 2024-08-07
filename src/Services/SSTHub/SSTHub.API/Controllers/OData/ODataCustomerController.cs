using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using SSTHub.Domain.Interfaces;
using SSTHub.Domain.ViewModels.Customer;
using System.Collections.Immutable;

namespace SSTHub.API.Controllers.OData
{
    [Route("api/odata/Customers")]
    [ApiController]
    public class ODataCustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public ODataCustomerController(ICustomerService customerService)
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
    }
}
