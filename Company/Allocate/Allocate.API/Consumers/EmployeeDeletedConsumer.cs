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
    public class EmployeeDeletedConsumer : IConsumer<EmployeeDeleted>
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;

        public EmployeeDeletedConsumer(IProjectService projectService, IMapper mapper)
        {
            _projectService = projectService;
            _mapper = mapper;
        }
        public async Task Consume(ConsumeContext<EmployeeDeleted> context)
        {
            Console.WriteLine(" =====> Employee delete Consumed");

            var employeeDeleted = context.Message;

            await _projectService.DeleteEmployee(employeeDeleted.Id);

        }
    }
}
