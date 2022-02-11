using Microsoft.EntityFrameworkCore;
using Onboard.Data.ApiModels;
using Onboard.Data.Context;
using Onboard.Data.Entities;
using Onboard.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onboard.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private OnboardDbContext _onboardDbContext;

        public EmployeeRepository(OnboardDbContext onboardDbContext)
        {
            _onboardDbContext = onboardDbContext;
        }

        public async Task<ResponseModel> CreateEmployee(Employee employee)
        {
            var existingEmployee = _onboardDbContext.Employees
                                                    .Where(x => 
                                                              x.FirstName == employee.FirstName 
                                                           && x.LastName == employee.LastName
                                                          )
                                                    .Any();
            if (existingEmployee)
            {
                return new ResponseModel(false,"Exployee Already Exists");
            }
            else
            {
                _onboardDbContext.Employees.Add(employee);
                await _onboardDbContext.SaveChangesAsync();
                return new ResponseModel(true, "Exployee created successfully", employee);
            }        
        }

        public async Task<ResponseModel> DeleteEmployee(int employeeId)
        {
            var employee = _onboardDbContext.Employees.Where(x => x.Id == employeeId).FirstOrDefault();

            if (employee != null)
            {
                employee.IsActive = false;
                employee.Relieve = DateTime.UtcNow;
                employee.MappedToProject = false;
                _onboardDbContext.Employees.Update(employee);
                await _onboardDbContext.SaveChangesAsync();
                return new ResponseModel(true, "Exployee deleted successfully");
            }
            else
            {
                return new ResponseModel(false, "Exployee do not exist");
            }
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees(bool IsActive)
        {
            return await _onboardDbContext.Employees.Where(x => x.IsActive == IsActive).ToListAsync();
        }

        public async Task<Employee> GetEmployee(int employeeId)
        {
            return await _onboardDbContext.Employees.Where(x => x.Id == employeeId && x.IsActive).FirstOrDefaultAsync();
        }

        public async Task<ResponseModel> UpdateEmployee(int employeeId, Employee employee)
        {
            var existingEmployee = _onboardDbContext.Employees.Where(x => x.Id == employeeId).FirstOrDefault();

            if (existingEmployee != null)
            {
                existingEmployee.ContactNumber = employee.ContactNumber;
                _onboardDbContext.Employees.Update(existingEmployee);
                await _onboardDbContext.SaveChangesAsync();
                return new ResponseModel(true, "Exployee updated successfully");
            }
            else
            {
                return new ResponseModel(false, "Exployee do not exist");
            }
        }

        public async Task MapEmployee(int employeeId)
        {
            var existingEmployee = _onboardDbContext.Employees.Where(x => x.Id == employeeId).FirstOrDefault();

            if (existingEmployee != null)
            {
                existingEmployee.MappedToProject = true;
                _onboardDbContext.Employees.Update(existingEmployee);
                await _onboardDbContext.SaveChangesAsync();
            }
        }


    }
}
