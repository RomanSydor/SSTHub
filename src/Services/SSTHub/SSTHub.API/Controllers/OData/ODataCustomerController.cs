using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using SSTHub.Domain.Interfaces;
using SSTHub.Domain.ViewModels.Customer;
using System.Collections.Immutable;

namespace SSTHub.API.Controllers.OData
{
    [Route("api/odata/Customers")]
    [ApiController]
    public class ODataCustomerController(ICustomerService _customerService) : ControllerBase
    {
        [EnableQuery]
        [HttpGet("ByOrganizationId/{organizationId}")]
        public Task<ImmutableList<CustomerListItemViewModel>> GetOrganizationId([FromRoute] int organizationId) => _customerService.GetByOrganizationIdAsync(organizationId);

        [EnableQuery]
        [HttpGet("ByHubId/{hubId}")]
        public Task<ImmutableList<CustomerListItemViewModel>> GetByHubId([FromRoute] int hubId) => _customerService.GetByHubIdAsync(hubId);
    }
}
