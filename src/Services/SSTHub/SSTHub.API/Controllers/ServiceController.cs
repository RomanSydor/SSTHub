﻿using Microsoft.AspNetCore.Mvc;
using SSTHub.Domain.Interfaces;
using SSTHub.Domain.ViewModels.Service;
using System.Net;

namespace SSTHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet("ByOrganizationId/{organizationId}")]
        [ProducesResponseType(typeof(IReadOnlyCollection<ServiceListItemViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(IReadOnlyCollection<ServiceListItemViewModel>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetByOrganizationId([FromRoute] int organizationId, [FromQuery] int amount = 20, [FromQuery] int page = 0)
        {
            try
            {
                var services = await _serviceService.GetByOrganizationIdAsync(organizationId, amount, page);
                return StatusCode(StatusCodes.Status200OK, services);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("ByEmployeeId/{employeeId}")]
        [ProducesResponseType(typeof(IReadOnlyCollection<ServiceListItemViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(IReadOnlyCollection<ServiceListItemViewModel>), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetByEmployeeId([FromRoute] int employeeId, [FromQuery] int amount = 20, [FromQuery] int page = 0)
        {
            try
            {
                var services = await _serviceService.GetByEmployeeIdAsync(employeeId, amount, page);
                return StatusCode(StatusCodes.Status200OK, services);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ServiceDetailsViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ServiceDetailsViewModel), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get([FromRoute] int id) 
        {
            try
            {
                var service = await _serviceService.GetByIdAsync(id);

                if (service != null)
                    return StatusCode(StatusCodes.Status200OK, service);

                return StatusCode(StatusCodes.Status404NotFound);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ServiceCreateViewModel createViewModel)
        {
            try
            {
                var serviceId = await _serviceService.CreateAsync(createViewModel);
                return StatusCode(StatusCodes.Status200OK, serviceId);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] ServiceEditItemViewModel editItemViewModel)
        {
            try
            {
                await _serviceService.UpdateAsync(id, editItemViewModel);
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
                await _serviceService.ChangeActiveStatusAsync(id);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
