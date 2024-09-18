using Microsoft.AspNetCore.Mvc;
using SSTHub.Domain.Interfaces;
using SSTHub.Domain.ViewModels.Event;

namespace SSTHub.API.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class EventController(IEventService _eventService) : ControllerBase
    {
        [HttpGet("{id}")]
        public Task<EventDetailsViewModel> GetById([FromRoute] int id) => _eventService.GetByIdAsync(id);

        [HttpPost]
        public Task<int> Create([FromBody] EventCreateViewModel createViewModel) => _eventService.CreateAsync(createViewModel);

        [HttpPatch("{id}")]
        public Task Edit([FromRoute] int id, [FromBody] EventEditItemViewModel editItemViewModel) => _eventService.UpdateAsync(id, editItemViewModel);
    }
}
