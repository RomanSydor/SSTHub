using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using SSTHub.Domain.Interfaces;
using SSTHub.Domain.ViewModels.Hub;

namespace SSTHub.API.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class HubController : ODataController
    {
        private readonly IHubService _hubService;

        public HubController(IHubService hubSerice) 
        {
            _hubService = hubSerice;
        }

        [HttpGet("{id}")]
        public async Task<HubDetailsViewModel> GetById([FromRoute] int id)
        {
            return await _hubService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<int> Create([FromBody] HubCreateViewModel createViewModel)
        {
            return await _hubService.CreateAsync(createViewModel);
        }

        [HttpPatch("{id}")]
        public async Task Edit([FromRoute]int id, [FromBody] HubEditItemViewModel editItemViewModel)
        {
            await _hubService.UpdateAsync(id, editItemViewModel);
        }

        [HttpPatch("{id}/ActiveStatus")]
        public async Task ChangeActiveStatus([FromRoute] int id)
        {
            await _hubService.ChangeActiveStatusAsync(id);
        }
    }
}
