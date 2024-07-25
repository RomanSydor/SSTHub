using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using SSTHub.Domain.Interfaces;
using SSTHub.Domain.ViewModels.Employee;
using System.Net;

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
        [ProducesResponseType(typeof(IReadOnlyCollection<EmployeeListItemViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(IReadOnlyCollection<EmployeeListItemViewModel>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get([FromRoute] int organizationId)
        {
            try
            {
                var employees = await _employeeService.GetByOrganizationIdAsync(organizationId);
                return StatusCode(StatusCodes.Status200OK, employees);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EmployeeDetailsViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(EmployeeDetailsViewModel), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var employee = await _employeeService.GetByIdAsync(id);
                if (employee != null)
                    return StatusCode(StatusCodes.Status200OK, employee);

                return StatusCode(StatusCodes.Status404NotFound);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmployeeCreateViewModel createViewModel)
        {
            try
            {
                var employeeId = await _employeeService.CreateAsync(createViewModel);
                return StatusCode(StatusCodes.Status200OK, employeeId);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Edit([FromRoute]int id, [FromBody] EmployeeEditItemViewModel editItemViewModel)
        {
            try
            {
                await _employeeService.UpdateAsync(id, editItemViewModel);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPatch("{id}/ActiveStatus")]
        public async Task<IActionResult> ChangeActiveStatus([FromRoute] int id)
        {
            try
            {
                await _employeeService.ChangeActiveStatusAsync(id);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
