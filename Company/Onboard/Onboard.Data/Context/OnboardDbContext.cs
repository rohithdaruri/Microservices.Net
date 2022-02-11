using Microsoft.EntityFrameworkCore;
using Onboard.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onboard.Data.Context
{
    public class OnboardDbContext : DbContext
    {
        public OnboardDbContext(DbContextOptions<OnboardDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }

    }
}
