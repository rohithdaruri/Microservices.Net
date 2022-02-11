using Allocate.Data.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allocate.Data.Context
{
    public class AllocateDbContext
    {
        private const string projectsCollectionName = "projects";
        private const string employeesCollectionName = "employees";

        public IMongoCollection<Project> Projects;
        public IMongoCollection<Employee> Employees;

        public AllocateDbContext(IConfiguration configuration)
        {
            var mongoClient = new MongoClient(configuration.GetConnectionString("AllocateConn"));
            var database = mongoClient.GetDatabase(configuration["Database"]);
            Projects = database.GetCollection<Project>(projectsCollectionName);
            Employees = database.GetCollection<Employee>(employeesCollectionName);

        }
    }

}
