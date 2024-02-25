using Microsoft.AspNetCore.Mvc;
using SSTHub.Domain.Interfaces;
using SSTHub.Domain.ViewModels.Hub;

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
    }
}
