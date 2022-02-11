using Allocate.Data.ApiModels;
using Allocate.Data.Entities;
using Allocate.Data.Interfaces;
using Allocate.Domain.Dtos;
using Allocate.Domain.Interfaces;
using AutoMapper;
using MassTransit;
using Messaging.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allocate.Domain.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;

        public ProjectService(IProjectRepository projectRepository, IMapper mapper, IPublishEndpoint publishEndpoint)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<ResponseModel> CreateProject(ProjectCreateDto projectCreate)
        {
            var project = _mapper.Map<Project>(projectCreate);
            project.Employees = new List<string>();
            return await _projectRepository.CreateProject(project);
        }

        public async Task<IEnumerable<ProjectReadDto>> GetAllProjects()
        {
            var dtos = await _projectRepository.GetAllProjects();
            return _mapper.Map<IEnumerable<ProjectReadDto>>(dtos);
        }

        public async Task<ProjectReadDto> GetProject(string projectId)
        {
            var dto = await _projectRepository.GetProject(projectId);
            return _mapper.Map<ProjectReadDto>(dto);
        }

        public async Task<IEnumerable<EmployeeReadDto>> GetAllEmployees()
        {
            var dtos = await _projectRepository.GetAllEmployees();
            return _mapper.Map<IEnumerable<EmployeeReadDto>>(dtos);
        }

        public async Task<EmployeeReadDto> GetEmployee(string employeeId)
        {
            var employee = await _projectRepository.GetEmployee(employeeId);
            var employeeRead = _mapper.Map<EmployeeReadDto>(employee);
            return employeeRead;
        }

        public async Task<ResponseModel> MapEmployeeToProject(string employeeId)
        {
            var employeeRead = await GetEmployee(employeeId);
            return await MapEmployeeToProject(employeeRead);
        }

        public async Task<ResponseModel> MapEmployeeToProject(EmployeeReadDto employeeRead)
        {
            var employee = _mapper.Map<Employee>(employeeRead);
            var response = await _projectRepository.MapEmployeeToProject(employee);
            if (response.IsSuccess)
            {
                await _publishEndpoint.Publish(new EmployeeMapped() { EmployeeId = employee.EmployeeId });
            }
            return response;
        }

        public async Task DeleteEmployee(int employeeId)
        {
            await _projectRepository.DeleteEmployee(employeeId);
        }
    }
}
