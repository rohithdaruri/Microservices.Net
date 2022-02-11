using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Onboard.Data.ApiModels;
using Onboard.Domain.Dtos;

namespace Onboard.Domain.Interfaces
{
    public interface IEmployeeService
    {
        Task<ResponseModel> CreateEmployee(EmployeeCreateDto employeeCreate);
        Task<ResponseModel> UpdateEmployee(int employeeId, EmployeeUpdateDto employeeUpdate);
        Task<ResponseModel> DeleteEmployee(int employeeId);
        Task<IEnumerable<EmployeeReadDto>> GetAllEmployees(bool IsActive);
        Task<EmployeeReadDto> GetEmployee(int employeeId);
        Task MapEmployee(int employeeId);
    }
}
