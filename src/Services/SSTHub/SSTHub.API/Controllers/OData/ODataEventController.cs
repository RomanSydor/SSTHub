using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using SSTHub.Domain.Interfaces;
using SSTHub.Domain.ViewModels.Event;
using System.Collections.Immutable;

namespace SSTHub.API.Controllers.OData
{
    [Route("api/odata/Events")]
    [ApiController]
    public class ODataEventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public ODataEventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [EnableQuery]
        [HttpGet("ByOrganizationId/{organizationId}")]
        public async Task<ImmutableList<EventListItemViewModel>> GetOrganizationId([FromRoute] int organizationId)
        {
            return await _eventService.GetByOrganizationIdAsync(organizationId);
        }

        [EnableQuery]
        [HttpGet("ByHubId/{hubId}")]
        public async Task<ImmutableList<EventListItemViewModel>> GetByHubId([FromRoute] int hubId)
        {
            return await _eventService.GetByHubIdAsync(hubId);
        }
    }
}
