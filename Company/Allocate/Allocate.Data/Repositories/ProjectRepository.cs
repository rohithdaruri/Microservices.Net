using Allocate.Data.ApiModels;
using Allocate.Data.Context;
using Allocate.Data.Entities;
using Allocate.Data.Interfaces;
using MassTransit;
using Messaging.Service.Contracts;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allocate.Data.Repositories
{
    public class ProjectRepository : IProjectRepository
    {

        private readonly AllocateDbContext _allocateDbContext;

        public ProjectRepository(AllocateDbContext allocateDbContext)
        {
            _allocateDbContext = allocateDbContext;
        }

        public async Task<IEnumerable<Project>> GetAllProjects()
        {
            return await _allocateDbContext.Projects.Find(Builders<Project>.Filter.Empty).ToListAsync();
        }

        public async Task<Project> GetProject(string id)
        {
            var filter = Builders<Project>.Filter.Eq(e => e.Id, id);
            return await _allocateDbContext.Projects.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<ResponseModel> CreateProject(Project project)
        {
            var projectFilter = Builders<Project>.Filter.Eq(e => e.Name, project.Name);
            var existingProject = await _allocateDbContext.Projects.Find(projectFilter).FirstOrDefaultAsync();

            if (existingProject == null)
            {
                await _allocateDbContext.Projects.InsertOneAsync(project);
                return new ResponseModel(true, "Project created successfully", project.Id);
            }
            else
            {
                return new ResponseModel(false, "Project already exists");
            }         
        }

        public async Task<ResponseModel> MapEmployeeToProject(Employee employee)
        {
            if (string.IsNullOrEmpty(employee.Id))
            {
                await _allocateDbContext.Employees.InsertOneAsync(employee);
            }
           
            var projectFilter = Builders<Project>.Filter.Eq(e => e.TechnicalStack, employee.TechnicalStack);
            var existingProject = await _allocateDbContext.Projects.Find(projectFilter).FirstOrDefaultAsync();

            if (existingProject != null)
            {
                var empList = existingProject.Employees;
                empList.Add(employee.Id);
                var projectUpdate = Builders<Project>.Update.Set("Employees", empList);
                await _allocateDbContext.Projects.UpdateOneAsync(projectFilter, projectUpdate);

                var employeeFilter = Builders<Employee>.Filter.Eq(e => e.EmployeeId, employee.EmployeeId);
                var employeeUpdate = Builders<Employee>.Update.Set("MappedToProject", true);
                await _allocateDbContext.Employees.UpdateOneAsync(employeeFilter, employeeUpdate);

                return new ResponseModel(true, "Employee mapped successfully", employee.EmployeeId);
            }
            else
            {
                return new ResponseModel(false, "Employee not mapped, Please create the project", employee.EmployeeId);
            }
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await _allocateDbContext.Employees.Find(Builders<Employee>.Filter.Empty).ToListAsync();
        }

        public async Task<Employee> GetEmployee(string employeeId)
        {
            var filter = Builders<Employee>.Filter.Eq(e => e.Id, employeeId);
            return await _allocateDbContext.Employees.Find(filter).FirstOrDefaultAsync();
        }

        public async Task DeleteEmployee(int employeeId)
        {
            var filter = Builders<Employee>.Filter.Eq(e => e.EmployeeId, employeeId);
            var employee = await _allocateDbContext.Employees.Find(filter).FirstOrDefaultAsync();

            var update = Builders<Project>.Update.Pull("Employees", employee.Id);

            _allocateDbContext.Projects.UpdateMany(Builders<Project>.Filter.Empty, update);

            await _allocateDbContext.Employees.DeleteOneAsync(filter);
        }
    }
}
