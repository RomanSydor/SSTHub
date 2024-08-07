using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using SSTHub.Domain.Interfaces;
using SSTHub.Domain.ViewModels.Service;
using System.Collections.Immutable;

namespace SSTHub.API.Controllers.OData
{
    [Route("api/odata/Services")]
    [ApiController]
    public class ODataServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ODataServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [EnableQuery]
        [HttpGet("ByOrganizationId/{organizationId}")]
        public async Task<ImmutableList<ServiceListItemViewModel>> GetByOrganizationId([FromRoute] int organizationId)
        {
            return await _serviceService.GetByOrganizationIdAsync(organizationId);
        }

        [EnableQuery]
        [HttpGet("ByEmployeeId/{employeeId}")]
        public async Task<ImmutableList<ServiceListItemViewModel>> GetByEmployeeId([FromRoute] int employeeId)
        {
            return await _serviceService.GetByEmployeeIdAsync(employeeId);
        }
    }
}
