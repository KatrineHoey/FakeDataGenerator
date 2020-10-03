using FakeDataGenerator.Server.Data;
using FakeDataGenerator.Server.Interfaces;
using FakeDataGenerator.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FakeDataGenerator.Server.Services
{
    public class HumidityService : IHumidityService
    {
        private readonly VentilationDBContext _ventilationDBContext;

        private static bool IsOn = false;

        public HumidityService(VentilationDBContext ventilationDBContext)
        {
            _ventilationDBContext = ventilationDBContext;
        }

        public async Task<bool> CreateHumidities(bool on)
        {
            IsOn = on;
            while (IsOn == true)
            {
                Humidity humidity = new Humidity();
                _ventilationDBContext.humidities.Add(humidity);
                await _ventilationDBContext.SaveChangesAsync();
                Thread.Sleep(5000);
            }

            return true;
        }

        public async Task<Guid> CreateHumidity(Humidity humidity)
        {
            _ventilationDBContext.humidities.Add(humidity);
            await _ventilationDBContext.SaveChangesAsync();

            return humidity.Id;
        }

        public async Task<bool> CleanDatabase()
        {
            var list = await _ventilationDBContext.humidities.OrderByDescending(x => x.DateCreated).ToListAsync();

            if (list.Count >= 10)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (i >= 10)
                    {
                        _ventilationDBContext.humidities.Remove(list[i]);
                    }
                }
            }

            await _ventilationDBContext.SaveChangesAsync();
            return true;

        }
    }
}
