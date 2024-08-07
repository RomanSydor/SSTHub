using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using SSTHub.Domain.Interfaces;
using SSTHub.Domain.ViewModels.Hub;
using System.Collections.Immutable;

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

        [EnableQuery]
        [HttpGet("ByOrganizationId/{organizationId}")]
        public async Task<ImmutableList<HubListItemViewModel>> GetByOrganizationId([FromRoute] int organizationId)
        {
            return await _hubService.GetByOrganizationIdAsync(organizationId);
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
