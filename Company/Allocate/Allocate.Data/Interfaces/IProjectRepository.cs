using Allocate.Data.ApiModels;
using Allocate.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allocate.Data.Interfaces
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetAllProjects();
        Task<Project> GetProject(string id);
        Task<ResponseModel> CreateProject(Project project);
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<ResponseModel> MapEmployeeToProject(Employee employee);
        Task<Employee> GetEmployee(string employeeId);
        Task DeleteEmployee(int employeeId);
    }
}
