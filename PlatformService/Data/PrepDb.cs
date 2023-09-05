using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Models;
using System;
using System.Linq;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            // as static class we can't have DI this is how we can get the service
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }

        }

        private static void SeedData(AppDbContext appDbContext)
        {
            if (!appDbContext.Platforms.Any())
            {
                Console.WriteLine("Seeding data");
                appDbContext.Platforms.AddRange(
                    new Platform() { Name = "Dot Net", Publisher = "Micrsoft", Cost = "Free" },
                    new Platform() { Name = "SQL server express", Publisher = "Micrsoft", Cost = "Free" },
                    new Platform() { Name = "kubernetes", Publisher = "Cloud native Computing Foundation", Cost = "Free" }
                );

                appDbContext.SaveChanges();
            }
            else
            {
                Console.WriteLine("Already seeded");
            }
        }

    }
}
