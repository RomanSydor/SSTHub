using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using SSTHub.Domain.Interfaces;
using SSTHub.Domain.ViewModels.Employee;
using System.Collections.Immutable;

namespace SSTHub.API.Controllers.OData
{
    [Route("api/odata/Employees")]
    [ApiController]
    public class ODataEmployeeController(IEmployeeService _employeeService) : ControllerBase
    {
        [EnableQuery]
        [HttpGet("ByOrganizationId/{organizationId}")]
        public Task<ImmutableList<EmployeeListItemViewModel>> Get([FromRoute] int organizationId) => _employeeService.GetByOrganizationIdAsync(organizationId);
    }
}
