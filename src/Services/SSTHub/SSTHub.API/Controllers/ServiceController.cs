using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using SSTHub.Domain.Interfaces;
using SSTHub.Domain.ViewModels.Service;
using System.Collections.Immutable;
using System.Net;

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

        [EnableQuery]
        [HttpGet("ByOrganizationId/{organizationId}")]
        public async Task<ImmutableList<ServiceListItemViewModel>> GetByOrganizationId([FromRoute] int organizationId)
        {
            return await _serviceService.GetByOrganizationIdAsync(organizationId);
        }

        [EnableQuery]
        [HttpGet("ByEmployeeId/{employeeId}")]
        public async Task<ImmutableList<ServiceListItemViewModel>> GetByEmployeeId([FromRoute] int employeeId)
        {
            return await _serviceService.GetByEmployeeIdAsync(employeeId);
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
