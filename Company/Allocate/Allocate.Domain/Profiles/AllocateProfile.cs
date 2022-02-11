using Allocate.Data.Entities;
using Allocate.Domain.Dtos;
using AutoMapper;
using Messaging.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allocate.Domain.Profiles
{
    public class AllocateProfile : Profile
    {
        public AllocateProfile()
        {
            // Source => Target
            CreateMap<Project, ProjectReadDto>();
            CreateMap<ProjectCreateDto, Project>();
            CreateMap<Employee, EmployeeReadDto>();
            CreateMap<EmployeeReadDto, Employee>();
            CreateMap<EmployeeCreated, EmployeeReadDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => ""))
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.EmployeeMail, opt => opt.MapFrom(src => src.FirstName + "." + src.LastName + "@company.com"))
                .ForMember(dest => dest.TechnicalStack, opt => opt.MapFrom(src => src.TechnicalStack))
                .ForMember(dest => dest.MappedToProject, opt => opt.MapFrom(src => false));
            

        }
    }
}
