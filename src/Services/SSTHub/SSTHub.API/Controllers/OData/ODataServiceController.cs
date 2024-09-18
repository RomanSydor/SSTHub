using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using SSTHub.Domain.Interfaces;
using SSTHub.Domain.ViewModels.Service;
using System.Collections.Immutable;

namespace SSTHub.API.Controllers.OData
{
    [Route("api/odata/Services")]
    [ApiController]
    public class ODataServiceController(IServiceService _serviceService) : ControllerBase
    {
        [EnableQuery]
        [HttpGet("ByOrganizationId/{organizationId}")]
        public Task<ImmutableList<ServiceListItemViewModel>> GetByOrganizationId([FromRoute] int organizationId) => _serviceService.GetByOrganizationIdAsync(organizationId);

        [EnableQuery]
        [HttpGet("ByEmployeeId/{employeeId}")]
        public Task<ImmutableList<ServiceListItemViewModel>> GetByEmployeeId([FromRoute] int employeeId) => _serviceService.GetByEmployeeIdAsync(employeeId);
    }
}
