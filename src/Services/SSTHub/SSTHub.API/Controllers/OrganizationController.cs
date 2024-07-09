using Microsoft.AspNetCore.Mvc;
using SSTHub.Domain.Interfaces;
using SSTHub.Domain.ViewModels.Organization;
using System.Net;

namespace SSTHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private readonly IOrganizationService _organizationService;

        public OrganizationController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrganizationCreateViewModel createViewModel)
        {
            try
            {
                var organizationId = await _organizationService.CreateAsync(createViewModel);
                return StatusCode(StatusCodes.Status200OK, organizationId);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] OrganizationEditItemViewModel editItemViewModel)
        {
            try
            {
                await _organizationService.UpdateAsync(id, editItemViewModel);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(OrganizationDetailsViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(OrganizationDetailsViewModel), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            try
            {
                var organization = await _organizationService.GetByIdAsync(id);

                if (organization != null)
                    return StatusCode(StatusCodes.Status200OK, organization);

                return StatusCode(StatusCodes.Status404NotFound);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
