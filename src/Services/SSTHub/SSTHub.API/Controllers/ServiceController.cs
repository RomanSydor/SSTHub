using Microsoft.AspNetCore.Mvc;
using SSTHub.Domain.Interfaces;
using SSTHub.Domain.ViewModels.Service;

namespace SSTHub.API.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet("{id}")]
        public async Task<ServiceDetailsViewModel> GetById([FromRoute] int id) 
        {
            return await _serviceService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<int> Create([FromBody] ServiceCreateViewModel createViewModel)
        {
            return await _serviceService.CreateAsync(createViewModel);
        }

        [HttpPatch("{id}")]
        public async Task Edit([FromRoute] int id, [FromBody] ServiceEditItemViewModel editItemViewModel)
        {
            await _serviceService.UpdateAsync(id, editItemViewModel);
        }

        [HttpPatch("{id}/ActiveStatus")]
        public async Task ChangeActiveStatus([FromRoute] int id)
        {
            await _serviceService.ChangeActiveStatusAsync(id);
        }
    }
}
