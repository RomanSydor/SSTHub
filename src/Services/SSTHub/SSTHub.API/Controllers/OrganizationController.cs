using Microsoft.AspNetCore.Mvc;
using SSTHub.Domain.Interfaces;
using SSTHub.Domain.ViewModels.Organization;

namespace SSTHub.API.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class OrganizationController(IOrganizationService _organizationService) : ControllerBase
    {
        [HttpGet("{id}")]
        public Task<OrganizationDetailsViewModel> Get([FromRoute] int id) => _organizationService.GetByIdAsync(id);

        [HttpPost]
        public Task<int> Create([FromBody] OrganizationCreateViewModel createViewModel) => _organizationService.CreateAsync(createViewModel);

        [HttpPatch("{id}")]
        public Task Edit([FromRoute] int id, [FromBody] OrganizationEditItemViewModel editItemViewModel) => _organizationService.UpdateAsync(id, editItemViewModel);
    }
}
