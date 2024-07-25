using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using SSTHub.Domain.Interfaces;
using SSTHub.Domain.ViewModels.Event;
using System.Net;

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
        [ProducesResponseType(typeof(IReadOnlyCollection<EventListItemViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(IReadOnlyCollection<EventListItemViewModel>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetOrganizationId([FromRoute] int organizationId)
        {
            try
            {
                var events = await _eventService.GetByOrganizationIdAsync(organizationId);
                return StatusCode(StatusCodes.Status200OK, events);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [EnableQuery]
        [HttpGet("ByHubId/{hubId}")]
        [ProducesResponseType(typeof(IReadOnlyCollection<EventListItemViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(IReadOnlyCollection<EventListItemViewModel>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetByHubId([FromRoute] int hubId)
        {
            try
            {
                var events = await _eventService.GetByHubIdAsync(hubId);
                return StatusCode(StatusCodes.Status200OK, events);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EventDetailsViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(EventDetailsViewModel), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var @event = await _eventService.GetByIdAsync(id);
                if (@event != null)
                    return StatusCode(StatusCodes.Status200OK, @event);

                return StatusCode(StatusCodes.Status404NotFound);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EventCreateViewModel createViewModel)
        {
            try
            {
                var eventId = await _eventService.CreateAsync(createViewModel);
                return StatusCode(StatusCodes.Status200OK, eventId);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] EventEditItemViewModel editItemViewModel)
        {
            try
            {
                await _eventService.UpdateAsync(id, editItemViewModel);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
