using Microsoft.AspNetCore.Mvc;
using SSTHub.Domain.Interfaces;
using SSTHub.Domain.ViewModels.Organization;

namespace SSTHub.API.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private readonly IOrganizationService _organizationService;

        public OrganizationController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        [HttpGet("{id}")]
        public async Task<OrganizationDetailsViewModel> Get([FromRoute] int id)
        {
            return await _organizationService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<int> Create([FromBody] OrganizationCreateViewModel createViewModel)
        {
            return await _organizationService.CreateAsync(createViewModel); 
        }

        [HttpPatch("{id}")]
        public async Task Edit([FromRoute] int id, [FromBody] OrganizationEditItemViewModel editItemViewModel)
        {
            await _organizationService.UpdateAsync(id, editItemViewModel);
        }
    }
}
