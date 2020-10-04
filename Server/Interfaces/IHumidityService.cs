using FakeDataGenerator.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeDataGenerator.Server.Interfaces
{
    public interface IHumidityService
    {
        Task<bool> CreateHumidities(Sensor sensor);

        Task<Guid> CreateHumidity(Humidity humidity);
        Task<bool> CleanDatabase();
    }
}
