using Microsoft.AspNetCore.Mvc;
using SSTHub.Domain.Interfaces;
using SSTHub.Domain.ViewModels.Hub;
using System.Net;

namespace SSTHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HubController : ControllerBase
    {
        private readonly IHubService _hubService;

        public HubController(IHubService hubSerice) 
        {
            _hubService = hubSerice;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] HubCreateViewModel createViewModel)
        {
            try
            {
                var hubId = await _hubService.CreateAsync(createViewModel);
                return StatusCode(StatusCodes.Status200OK, hubId);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Edit([FromRoute]int id, [FromBody] HubEditItemViewModel editItemViewModel)
        {
            try
            {
                await _hubService.UpdateAsync(id, editItemViewModel);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPatch("{id}/ActiveStatus")]
        public async Task<IActionResult> ChangeActiveStatus([FromRoute] int id)
        {
            try
            {
                await _hubService.ChangeActiveStatusAsync(id);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(HubDetailsViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(HubDetailsViewModel), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            try
            {
                var hub = await _hubService.GetByIdAsync(id);

                if (hub != null)
                    return StatusCode(StatusCodes.Status200OK, hub);

                return StatusCode(StatusCodes.Status404NotFound);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
