using FakeDataGenerator.Server.Data;
using FakeDataGenerator.Server.Interfaces;
using FakeDataGenerator.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeDataGenerator.Server.Services
{
    public class SensorService : ISensorService
    {
        private readonly VentilationDBContext _ventilationDBContext;

        public SensorService(VentilationDBContext ventilationDBContext)
        {
            _ventilationDBContext = ventilationDBContext;
        }


        public async Task<List<Sensor>> GetSensors()
        {
            return await _ventilationDBContext.sensors.AsNoTracking()
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public async Task<Sensor> GetSensor(int id)
        {
            return await _ventilationDBContext.sensors.AsNoTracking()
                .Where(x => x.SensorId == id)
                .FirstOrDefaultAsync();
        }

        //public async Task<bool> UpdateSensor(Sensor sensor)
        //{
        //    Sensor s = await _ventilationDBContext.sensors.FindAsync(sensor.SensorId);
        //    if (sensor.SensorId <= 0) return false;

        //    s.Name = sensor.Name;
        //    s.IsOn = sensor.IsOn;            

        //    _ventilationDBContext.SaveChanges();
        //    return true;
        //}

        public async Task<int> CreateSensor(Sensor sensor)
        {
            _ventilationDBContext.sensors.Add(sensor);
            await _ventilationDBContext.SaveChangesAsync();

            return sensor.SensorId;
        }


        public async Task<bool> UpdateSensor(Sensor sensor)
        {
            _ventilationDBContext.Entry(sensor).State = EntityState.Modified;
            await _ventilationDBContext.SaveChangesAsync();
            return true;
        }

        public async Task DeleteSensor(int id)
        {
            var sensor = new Sensor { SensorId = id };
            _ventilationDBContext.sensors.Remove(sensor);
            await _ventilationDBContext.SaveChangesAsync();
        }

    }
}
