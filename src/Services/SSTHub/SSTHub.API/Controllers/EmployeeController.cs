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
            var vehicles = await _employeeService.GetAsync(amount, page);
            return Ok(vehicles);
        }
    }
}
