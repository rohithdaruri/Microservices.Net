using AutoMapper;
using MassTransit;
using Messaging.Service.Contracts;
using Onboard.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onboard.API.Consumers
{
    public class EmployeeMappedConsumer : IConsumer<EmployeeMapped>
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeeMappedConsumer(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }
        public async Task Consume(ConsumeContext<EmployeeMapped> context)
        {
            Console.WriteLine(" =====> Employee Map Consumed");

            var employeeMapped = context.Message;

            await _employeeService.MapEmployee(employeeMapped.EmployeeId);

        }
    }
}
