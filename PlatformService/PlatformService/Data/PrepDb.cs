using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
        }

        private static void SeedData(AppDbContext context)
        {
            if (!context.Platforms.Any())
            {
                Console.WriteLine("--> Seeding data ...");
                
                context.Platforms.AddRange(new List<Platform>
                {
                    new() { Name = "DotNet", Publisher = "Microsoft", Cost = "Free" },
                    new() { Name = "SQL Server", Publisher = "Microsoft", Cost = "Free" },
                    new() { Name = "Kubernates", Publisher = "CNCF", Cost = "Free" }
                });

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> Context already has data");
            }
        }
    }
}