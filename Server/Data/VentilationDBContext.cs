using FakeDataGenerator.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeDataGenerator.Server.Data
{
    public class VentilationDBContext : DbContext
    {
        public VentilationDBContext(DbContextOptions<VentilationDBContext> options) : base(options)
        {

        }

        public DbSet<Humidity> humidities { get; set; }

        public DbSet<Sensor> sensors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SensorMeasure>()
                .HasOne(p => p.Sensor)
                .WithMany(b => b.SensorMeasures);
        }
    }
}
