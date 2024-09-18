using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using SSTHub.Domain.Interfaces;
using SSTHub.Domain.ViewModels.Event;
using System.Collections.Immutable;

namespace SSTHub.API.Controllers.OData
{
    [Route("api/odata/Events")]
    [ApiController]
    public class ODataEventController(IEventService _eventService) : ControllerBase
    {
        [EnableQuery]
        [HttpGet("ByOrganizationId/{organizationId}")]
        public Task<ImmutableList<EventListItemViewModel>> GetOrganizationId([FromRoute] int organizationId) => _eventService.GetByOrganizationIdAsync(organizationId);

        [EnableQuery]
        [HttpGet("ByHubId/{hubId}")]
        public Task<ImmutableList<EventListItemViewModel>> GetByHubId([FromRoute] int hubId) => _eventService.GetByHubIdAsync(hubId);
    }
}
