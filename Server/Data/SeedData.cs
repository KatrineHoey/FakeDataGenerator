
using FakeDataGenerator.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeDataGenerator.Server.Data
{
    public class SeedData
    {
        public static void InitializeHumidity(IServiceProvider serviceProvider)
        {
            using (var context = new VentilationDBContext(
                serviceProvider.GetRequiredService<DbContextOptions<VentilationDBContext>>()))
            {
                context.Database.EnsureCreated();
                // Look for any heroes.
                if (context.humidities.Any())
                {
                    return;   // Data was already seeded
                }

                context.humidities.AddRange(
                    new Humidity(),
                    new Humidity());
                    

                context.SaveChanges();
            }



        }
    }
}
