using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using SSTHub.Domain.Interfaces;
using SSTHub.Domain.ViewModels.Employee;
using System.Collections.Immutable;

namespace SSTHub.API.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [EnableQuery]
        [HttpGet("ByOrganizationId/{organizationId}")]
        public async Task<ImmutableList<EmployeeListItemViewModel>> Get([FromRoute] int organizationId)
        {
            return await _employeeService.GetByOrganizationIdAsync(organizationId);
        }

        [HttpGet("{id}")]
        public async Task<EmployeeDetailsViewModel> GetById([FromRoute] int id)
        {
            return await _employeeService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<int> Create([FromBody] EmployeeCreateViewModel createViewModel)
        {
            return await _employeeService.CreateAsync(createViewModel);
        }

        [HttpPatch("{id}")]
        public async Task Edit([FromRoute]int id, [FromBody] EmployeeEditItemViewModel editItemViewModel)
        {
            await _employeeService.UpdateAsync(id, editItemViewModel);
        }

        [HttpPatch("{id}/ActiveStatus")]
        public async Task ChangeActiveStatus([FromRoute] int id)
        {
            await _employeeService.ChangeActiveStatusAsync(id);
        }
    }
}
