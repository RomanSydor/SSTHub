using Microsoft.AspNetCore.Mvc;
using SSTHub.Domain.Interfaces;
using SSTHub.Domain.ViewModels.Customer;

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

        [HttpPost]
        public async Task<int> Create([FromBody] CustomerCreateViewModel createViewModel)
        {
            return await _customerService.CreateAsync(createViewModel);
        }
    }
}
