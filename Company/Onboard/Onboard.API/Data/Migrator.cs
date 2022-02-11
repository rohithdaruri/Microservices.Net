using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Onboard.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onboard.API.Data
{
    public static class Migrator
    {
        public static void Migrate(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                Migrate(serviceScope.ServiceProvider.GetService<OnboardDbContext>());
            }
        }

        private static void Migrate(OnboardDbContext context)
        {
            Console.WriteLine(" ===> Applying Migrations......");
            try
            {
                context.Database.Migrate();
            }
            catch (Exception ex)
            {
                Console.WriteLine(" ===> Not applied Migrations, Reason : " + ex.ToString());
            }
        }

    }
}
