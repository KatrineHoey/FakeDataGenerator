using FakeDataGenerator.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeDataGenerator.Server.Interfaces
{
    public interface ISensorService
    {
        Task<bool> UpdateSensor(Sensor sensor);
        Task<List<Sensor>> GetSensors();
        Task<Sensor> GetSensor(int id);
        Task<int> CreateSensor(Sensor sensor);
        Task DeleteSensor(int id);
    }
}
