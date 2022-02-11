using AutoMapper;
using MassTransit;
using Messaging.Service.Contracts;
using Microsoft.Extensions.Logging;
using Onboard.Data.ApiModels;
using Onboard.Data.Entities;
using Onboard.Data.Interfaces;
using Onboard.Domain.Dtos;
using Onboard.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onboard.Domain.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<EmployeeService> _logger;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;

        public EmployeeService(IEmployeeRepository employeeRepository, ILogger<EmployeeService> logger, IMapper mapper, IPublishEndpoint publishEndpoint)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<ResponseModel> CreateEmployee(EmployeeCreateDto employeeCreate)
        {
            var employee = _mapper.Map<Employee>(employeeCreate);
            employee.Joined = DateTime.UtcNow;
            employee.IsActive = true;
            employee.MappedToProject = false;
            var response = await _employeeRepository.CreateEmployee(employee);
        
            if (response.data != null)
            {
                // Return Value Creation
                var employeeRead = _mapper.Map<EmployeeReadDto>(response.data);
                var retValue = new ResponseModel(response.IsSuccess, response.Description, employeeRead);

                // Publish Message
                var employeeCreated = _mapper.Map<EmployeeCreated>(response.data);
                await _publishEndpoint.Publish(employeeCreated);

                return retValue;
            }
            else
            {
                return response;
            }     
        }

        public async Task<ResponseModel> DeleteEmployee(int employeeId)
        {
            var response = await _employeeRepository.DeleteEmployee(employeeId);
            if (response.IsSuccess)
            {
                var employeeDeleted = new EmployeeDeleted { Id = employeeId };
                await _publishEndpoint.Publish(employeeDeleted);
            }
            return response;
        }

        public async Task<ResponseModel> UpdateEmployee(int employeeId, EmployeeUpdateDto employeeUpdate)
        {
            var employee = _mapper.Map<Employee>(employeeUpdate);
            return await _employeeRepository.UpdateEmployee(employeeId, employee);
        }

        public async Task<IEnumerable<EmployeeReadDto>> GetAllEmployees(bool IsActive)
        {
            var employees = await _employeeRepository.GetAllEmployees(IsActive);
            return _mapper.Map<IEnumerable<EmployeeReadDto>>(employees);
        }

        public async Task<EmployeeReadDto> GetEmployee(int employeeId)
        {
            var employee = await _employeeRepository.GetEmployee(employeeId);
            return _mapper.Map<EmployeeReadDto>(employee);
        }

        public async Task MapEmployee(int employeeId)
        {
            await _employeeRepository.MapEmployee(employeeId);
        }
    }
}
