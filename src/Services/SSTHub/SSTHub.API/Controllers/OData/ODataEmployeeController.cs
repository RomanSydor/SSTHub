using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using SSTHub.Domain.Interfaces;
using SSTHub.Domain.ViewModels.Employee;
using System.Collections.Immutable;

namespace SSTHub.API.Controllers.OData
{
    [Route("api/odata/Employees")]
    [ApiController]
    public class ODataEmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public ODataEmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [EnableQuery]
        [HttpGet("ByOrganizationId/{organizationId}")]
        public async Task<ImmutableList<EmployeeListItemViewModel>> Get([FromRoute] int organizationId)
        {
            return await _employeeService.GetByOrganizationIdAsync(organizationId);
        }
    }
}
