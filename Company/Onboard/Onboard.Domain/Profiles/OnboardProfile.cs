using AutoMapper;
using Messaging.Service.Contracts;
using Onboard.Data.Entities;
using Onboard.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onboard.Domain.Profiles
{
    public class OnboardProfile : Profile
    {
        public OnboardProfile()
        {
            // Source => Target
            CreateMap<Employee, EmployeeReadDto>();
            CreateMap<EmployeeCreateDto, Employee>();
            CreateMap<EmployeeUpdateDto, Employee>();
            CreateMap<Employee, EmployeeCreated>();
        }
    }
}
