
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

                if (context.humidities.Any())
                {
                    return;   // Data was already seeded
                }

                context.humidities.AddRange(
                    new Humidity(1),
                    new Humidity(1));
                    

                context.SaveChanges();
            }



        }

        public static void InitializeSensors(IServiceProvider serviceProvider)
        {
            using (var context = new VentilationDBContext(
                serviceProvider.GetRequiredService<DbContextOptions<VentilationDBContext>>()))
            {
                context.Database.EnsureCreated();

                if (context.sensors.Any())
                {
                    return;   // Data was already seeded
                }

                context.sensors.AddRange(
                    new Sensor(DataTypeEnum.Humidity, "H1", "%"),
                    new Sensor(DataTypeEnum.Humidity, "H2", "%"),
                    new Sensor(DataTypeEnum.Humidity, "H3", "%"));


                context.SaveChanges();
            }



        }
    }
}
