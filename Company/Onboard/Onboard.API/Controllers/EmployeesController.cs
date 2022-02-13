using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Onboard.Data.ApiModels;
using Onboard.Domain.Dtos;
using Onboard.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onboard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseModel>> GetAllEmployees([FromQuery] bool IsActive)
        {
            var response = await _employeeService.GetAllEmployees(IsActive);

            if (response == null || response.Count() == 0)
            {
                return Ok(new ResponseModel(false, "Employees not exists", response));
            }

            return Ok(new ResponseModel(true, "Employees exists", response));
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("{employeeId}")]
        public async Task<ActionResult<ResponseModel>> GetEmployee([FromRoute] int employeeId)
        {
            var response = await _employeeService.GetEmployee(employeeId);

            if (response == null)
            {
                return Ok(new ResponseModel(false, "Employee not found", response));
            }

            return Ok(new ResponseModel(true, "Employee found", response));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseModel>> CreateEmployee([FromBody] EmployeeCreateDto employeeCreate)
        {
            var response = await _employeeService.CreateEmployee(employeeCreate);
            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("{employeeId}")]
        public async Task<ActionResult<ResponseModel>> UpdateEmployee([FromRoute] int employeeId, [FromBody] EmployeeUpdateDto employeeUpdate)
        {
            var response = await _employeeService.UpdateEmployee(employeeId, employeeUpdate);
            return Ok(response);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("{employeeId}")]
        public async Task<ActionResult<ResponseModel>> DeleteEmployee([FromRoute] int employeeId)
        {
            var response = await _employeeService.DeleteEmployee(employeeId);
            return Ok(response);
        }

    }
}
