using Microsoft.AspNetCore.Mvc;
using SSTHub.Domain.Interfaces;
using SSTHub.Domain.ViewModels.Employee;
using System.Net;

namespace SSTHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IReadOnlyCollection<EmployeeListItemViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(IReadOnlyCollection<EmployeeListItemViewModel>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAll([FromQuery] int amount = 20, [FromQuery] int page = 0)
        {
            var employees = await _employeeService.GetAsync(amount, page);
            return Ok(employees);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EmployeeDetailsViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(EmployeeDetailsViewModel), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var employee = await _employeeService.GetByIdAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Edit([FromRoute]int id, [FromBody] EmployeeEditItemViewModel employeeEditItemViewModel)
        {
            bool result;

            try
            {
                result = await _employeeService.UpdateAsync(id, employeeEditItemViewModel);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "Something went wrong. " + e.Message });
            }

            if (!result)
            {
                return BadRequest(new { Message = "Something went wrong." });
            }

            return Ok(new { Message = "Updated" });
        }

        [HttpPatch("{id}/ActiveStatus")]
        public async Task<IActionResult> ChangeActiveStatus([FromRoute] int id)
        {
            bool result;

            try
            {
                result = await _employeeService.ChangeActiveStatusAsync(id);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "Something went wrong. " + e.Message });
            }

            if (!result)
            {
                return BadRequest(new { Message = "Something went wrong." });
            }

            return Ok(new { Message = "Updated" });
        }
    }
}
