using Onboard.Data.ApiModels;
using Onboard.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onboard.Data.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<ResponseModel> CreateEmployee(Employee employee);
        Task<ResponseModel> UpdateEmployee(int employeeId, Employee employee);
        Task<ResponseModel> DeleteEmployee(int employeeId);
        Task<IEnumerable<Employee>> GetAllEmployees(bool IsActive);
        Task<Employee> GetEmployee(int employeeId);
        Task MapEmployee(int employeeId);
    }
}
