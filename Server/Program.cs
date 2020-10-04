﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FakeDataGenerator.Server.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FakeDataGenerator.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1. Get the IWebHost which will host this application.
            var host = CreateHostBuilder(args).Build();

            //2. Find the service layer within our scope.
            using (var scope = host.Services.CreateScope())
            {
                //3. Get the instance of VentilationDBContext in our services layer
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<VentilationDBContext>();


                //4. Call the DataGenerator to create sample data
                SeedData.InitializeSensors(services);
                SeedData.InitializeHumidity(services);
            }

            //Continue to run the application
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
