using Microsoft.AspNetCore.Mvc;
using SSTHub.Domain.Interfaces;
using SSTHub.Domain.ViewModels.Customer;

namespace SSTHub.API.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class CustomerController(ICustomerService _customerService) : ControllerBase
    {
        [HttpPost]
        public Task<int> Create([FromBody] CustomerCreateViewModel createViewModel) => _customerService.CreateAsync(createViewModel);
    }
}
