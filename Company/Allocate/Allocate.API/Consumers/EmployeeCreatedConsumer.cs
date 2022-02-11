using Allocate.Domain.Dtos;
using Allocate.Domain.Interfaces;
using AutoMapper;
using MassTransit;
using Messaging.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Allocate.API.Consumers
{
    public class EmployeeCreatedConsumer : IConsumer<EmployeeCreated>
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;

        public EmployeeCreatedConsumer(IProjectService projectService, IMapper mapper)
        {
            _projectService = projectService;
            _mapper = mapper;
        }
        public async Task Consume(ConsumeContext<EmployeeCreated> context)
        {
            Console.WriteLine(" =====> Employee Consumed");
            
            var employeeCreated = context.Message;
            
            var employee = _mapper.Map<EmployeeReadDto>(employeeCreated);
            
            await _projectService.MapEmployeeToProject(employee);

        }
    }
}
