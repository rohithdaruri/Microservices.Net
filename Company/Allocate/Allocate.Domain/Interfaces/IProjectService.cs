using Allocate.Data.ApiModels;
using Allocate.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allocate.Domain.Interfaces
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectReadDto>> GetAllProjects();
        Task<ResponseModel> CreateProject(ProjectCreateDto projectCreate);
        Task<ProjectReadDto> GetProject(string projectId);
        Task<IEnumerable<EmployeeReadDto>> GetAllEmployees();
        Task<EmployeeReadDto> GetEmployee(string employeeId);
        Task<ResponseModel> MapEmployeeToProject(string employeeId);
        Task<ResponseModel> MapEmployeeToProject(EmployeeReadDto employeeRead);
        Task DeleteEmployee(int employeeId);
    }
}
