using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using SSTHub.Domain.Interfaces;
using SSTHub.Domain.ViewModels.Customer;
using System.Net;

namespace SSTHub.API.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [EnableQuery]
        [HttpGet("ByOrganizationId/{organizationId}")]
        [ProducesResponseType(typeof(IReadOnlyCollection<CustomerListItemViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(IReadOnlyCollection<CustomerListItemViewModel>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetOrganizationId([FromRoute] int organizationId)
        {
            try
            {
                var customers = await _customerService.GetByOrganizationIdAsync(organizationId);
                return StatusCode(StatusCodes.Status200OK, customers);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [EnableQuery]
        [HttpGet("ByHubId/{hubId}")]
        [ProducesResponseType(typeof(IReadOnlyCollection<CustomerListItemViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(IReadOnlyCollection<CustomerListItemViewModel>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetByHubId([FromRoute] int hubId)
        {
            try
            {
                var customers = await _customerService.GetByHubIdAsync(hubId);
                return StatusCode(StatusCodes.Status200OK, customers);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CustomerCreateViewModel createViewModel)
        {
            try
            {
                var customerId = await _customerService.CreateAsync(createViewModel);
                return StatusCode(StatusCodes.Status200OK, customerId);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
