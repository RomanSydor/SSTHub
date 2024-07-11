using Microsoft.AspNetCore.Mvc;
using SSTHub.Domain.Interfaces;
using SSTHub.Domain.ViewModels.Customer;
using System.Net;

namespace SSTHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("ByOrganizationId/{organizationId}")]
        [ProducesResponseType(typeof(IReadOnlyCollection<CustomerListItemViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(IReadOnlyCollection<CustomerListItemViewModel>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetOrganizationId([FromRoute] int organizationId, [FromQuery] int amount = 20, [FromQuery] int page = 0)
        {
            try
            {
                var customers = await _customerService.GetByOrganizationIdAsync(organizationId, amount, page);
                return StatusCode(StatusCodes.Status200OK, customers);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("ByHubId/{hubId}")]
        [ProducesResponseType(typeof(IReadOnlyCollection<CustomerListItemViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(IReadOnlyCollection<CustomerListItemViewModel>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetByHubId([FromRoute] int hubId, [FromQuery] int amount = 20, [FromQuery] int page = 0)
        {
            try
            {
                var customers = await _customerService.GetByHubIdAsync(hubId, amount, page);
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
