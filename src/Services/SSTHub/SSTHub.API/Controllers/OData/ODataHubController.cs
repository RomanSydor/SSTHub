using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using SSTHub.Domain.Interfaces;
using SSTHub.Domain.ViewModels.Hub;
using System.Collections.Immutable;

namespace SSTHub.API.Controllers.OData
{
    [Route("api/odata/Hubs")]
    [ApiController]
    public class ODataHubController(IHubService _hubService) : ControllerBase
    {
        [EnableQuery]
        [HttpGet("ByOrganizationId/{organizationId}")]
        public Task<ImmutableList<HubListItemViewModel>> GetByOrganizationId([FromRoute] int organizationId) => _hubService.GetByOrganizationIdAsync(organizationId);
    }
}
