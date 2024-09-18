using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using SSTHub.Domain.Interfaces;
using SSTHub.Domain.ViewModels.Hub;

namespace SSTHub.API.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class HubController(IHubService _hubService) : ODataController
    {
        [HttpGet("{id}")]
        public Task<HubDetailsViewModel> GetById([FromRoute] int id) => _hubService.GetByIdAsync(id);

        [HttpPost]
        public Task<int> Create([FromBody] HubCreateViewModel createViewModel) => _hubService.CreateAsync(createViewModel);

        [HttpPatch("{id}")]
        public Task Edit([FromRoute] int id, [FromBody] HubEditItemViewModel editItemViewModel) => _hubService.UpdateAsync(id, editItemViewModel);

        [HttpPatch("{id}/ActiveStatus")]
        public Task ChangeActiveStatus([FromRoute] int id) => _hubService.ChangeActiveStatusAsync(id);
    }
}
