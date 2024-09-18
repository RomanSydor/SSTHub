using Microsoft.AspNetCore.Mvc;
using SSTHub.Domain.Interfaces;
using SSTHub.Domain.ViewModels.Employee;

namespace SSTHub.API.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class EmployeeController(IEmployeeService _employeeService) : ControllerBase
    {
        [HttpGet("{id}")]
        public Task<EmployeeDetailsViewModel> GetById([FromRoute] int id) => _employeeService.GetByIdAsync(id);

        [HttpPost]
        public Task<int> Create([FromBody] EmployeeCreateViewModel createViewModel) => _employeeService.CreateAsync(createViewModel);

        [HttpPatch("{id}")]
        public Task Edit([FromRoute] int id, [FromBody] EmployeeEditItemViewModel editItemViewModel) => _employeeService.UpdateAsync(id, editItemViewModel);

        [HttpPatch("{id}/ActiveStatus")]
        public Task ChangeActiveStatus([FromRoute] int id) => _employeeService.ChangeActiveStatusAsync(id);
    }
}