using Microsoft.AspNetCore.Mvc;
using SSTHub.Domain.Interfaces;
using SSTHub.Domain.ViewModels.Event;

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
