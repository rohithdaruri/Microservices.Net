using Allocate.Data.ApiModels;
using Allocate.Domain.Dtos;
using Allocate.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Allocate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseModel>> GetAllProjects()
        {
            var response = await _projectService.GetAllProjects();

            if (response == null || response.Count() == 0)
            {
                return Ok(new ResponseModel(false, "Projects not exists", response));
            }

            return Ok(new ResponseModel(true, "Projects exists", response));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("{projectId}")]
        public async Task<ActionResult<ResponseModel>> GetProject(string projectId)
        {
            var response = await _projectService.GetProject(projectId);

            if (response == null)
            {
                return Ok(new ResponseModel(false, "Project not found", response));
            }

            return Ok(new ResponseModel(true, "Project found", response));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseModel>> CreateProject([FromBody] ProjectCreateDto projectCreate)
        {
            var response = await _projectService.CreateProject(projectCreate);

            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("AllEmployees")]
        public async Task<ActionResult<ResponseModel>> GetAllEmployees()
        {           
            var response = await _projectService.GetAllEmployees();

            if (response == null || response.Count() == 0)
            {
                return Ok(new ResponseModel(false, "Exployees not exists", response));
            }

            return Ok(new ResponseModel(true, "Exployees exists", response));
        }

        [HttpPut]
        [Route("MapEmployeeToProject")]
        public async Task<ActionResult<ResponseModel>> MapEmployeeToProject(string employeeId)
        {
            return await _projectService.MapEmployeeToProject(employeeId);
        }


    }
}
