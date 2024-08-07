using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using SSTHub.Domain.Interfaces;
using SSTHub.Domain.ViewModels.Event;
using System.Collections.Immutable;

namespace SSTHub.API.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
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

        [HttpGet("{id}")]
        public async Task<EventDetailsViewModel> GetById([FromRoute] int id)
        {
            return await _eventService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<int> Create([FromBody] EventCreateViewModel createViewModel)
        {
            return await _eventService.CreateAsync(createViewModel);
        }

        [HttpPatch("{id}")]
        public async Task Edit([FromRoute] int id, [FromBody] EventEditItemViewModel editItemViewModel)
        {
            await _eventService.UpdateAsync(id, editItemViewModel);
        }
    }
}
