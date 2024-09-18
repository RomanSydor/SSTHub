using Microsoft.AspNetCore.Mvc;
using SSTHub.Domain.Interfaces;
using SSTHub.Domain.ViewModels.Service;

namespace SSTHub.API.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class ServiceController(IServiceService _serviceService) : ControllerBase
    {
        [HttpGet("{id}")]
        public Task<ServiceDetailsViewModel> GetById([FromRoute] int id) => _serviceService.GetByIdAsync(id);

        [HttpPost]
        public Task<int> Create([FromBody] ServiceCreateViewModel createViewModel) => _serviceService.CreateAsync(createViewModel);

        [HttpPatch("{id}")]
        public Task Edit([FromRoute] int id, [FromBody] ServiceEditItemViewModel editItemViewModel) => _serviceService.UpdateAsync(id, editItemViewModel);

        [HttpPatch("{id}/ActiveStatus")]
        public Task ChangeActiveStatus([FromRoute] int id) => _serviceService.ChangeActiveStatusAsync(id);
    }
}
