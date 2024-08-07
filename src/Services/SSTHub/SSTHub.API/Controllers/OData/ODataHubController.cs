using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using SSTHub.Domain.Interfaces;
using SSTHub.Domain.ViewModels.Hub;
using System.Collections.Immutable;

namespace SSTHub.API.Controllers.OData
{
    [Route("api/odata/Hubs")]
    [ApiController]
    public class ODataHubController : ControllerBase
    {
        private readonly IHubService _hubService;

        public ODataHubController(IHubService hubSerice)
        {
            _hubService = hubSerice;
        }

        [EnableQuery]
        [HttpGet("ByOrganizationId/{organizationId}")]
        public async Task<ImmutableList<HubListItemViewModel>> GetByOrganizationId([FromRoute] int organizationId)
        {
            return await _hubService.GetByOrganizationIdAsync(organizationId);
        }
    }
}
